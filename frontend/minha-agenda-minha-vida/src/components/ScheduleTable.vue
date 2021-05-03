<template> 
  <v-card>
    <div class="top-table">
      <!-- Barra de pesquisa -->
      <v-text-field
        v-model="search"
        append-icon="mdi-magnify"
        label="Search"
        single-line
        hide-details
      ></v-text-field>
      <!-- / Barra de pesquisa -->

      <!-- Nova agenda -->
      <Modal width="750" isIconCloseContent :closeModal="closeModal">
        <v-btn class="mx-2" fab slot="clickable" color="primary">
          <v-icon dark> mdi-plus </v-icon>
        </v-btn>
        <FormSchedule slot="content" :reloadSchedules="reloadSchedules" />
      </Modal>
      <!-- /Nova agenda -->
    </div>

    <v-data-table
      :headers="headers"
      :items="schedules"
      :search="search"
      sort-by="id"
      class="elevation-1"
      
    >
      <template v-slot:top>
        <v-progress-linear
          v-if="loading"
          indeterminate
          color="cyan"
        ></v-progress-linear>
      </template>

      <!-- Ações  -->
      <template v-slot:item.actions="{item}">
        <div class="d-flex">
          <!-- Visualizar -->
          <Modal width="750" isIconCloseContent>
            <v-icon color="success" slot="clickable"> mdi-eye-outline </v-icon>
            <FormSchedule
              slot="content"
              :scheduleReceived="item"
              :isReadonly="true"
            />
          </Modal>
          <!-- Visualizar -->

          <!-- Editar -->
          <Modal width="750" isIconCloseContent :closeModal="closeModal">
            <v-icon color="primary" slot="clickable"> mdi-pencil </v-icon>
            <FormSchedule
              slot="content"
              :reloadSchedules="reloadSchedules"
              :scheduleReceived="item"
            />
          </Modal>
          <!-- / Editar -->

          <v-icon color="error" @click="deleteItem(item.id)">
            mdi-delete
          </v-icon>
        </div>
      </template>
      <!-- / Ações  -->
    </v-data-table>
  </v-card>
</template>

<script>
import { AgendaApi } from "../api/AgendaApi.js";
import Modal from "./_generics/Modal";
import FormSchedule from "./FormSchedule";

export default {
  components: { Modal, FormSchedule },
  data: () => ({
    search: "",
    headers: [
      { text: "Id", sortable: true, value: "id" },
      { text: "Titulo", value: "titulo" },
      { text: "Ações", value: "actions" },
    ],
    schedules: [],
    loading: 0,
    reloadSchedules: Function,
    closeModal: false,
  }),

  created() {
    this.reloadSchedules = this.loadSchedules;
    this.loadSchedules();
  },

  methods: {
    async loadSchedules() {
      this.loading++;

      const resp = await AgendaApi.Agenda.getAll();

      if (resp.status == 400) {
        this.$toasted?.global.error({
          mensagem: "Erro ao buscar as agendas",
        });
        this.loading--;
        return;
      }

      this.normalizeData(resp);

      this.schedules = resp;

      this.closeModal = !this.closeModal;

      this.loading--;
    },

    async deleteItem(scheduleId) {
      this.loading++;

      const resp = await AgendaApi.Agenda.delete(scheduleId);

      if (!resp) {
        this.$toasted?.global.error({ mensagem: "Erro ao deletar o item" });
        return;
      }

      this.loadSchedules();

      this.$toasted?.global.success({ mensagem: "Item deletado com sucesso" });

      this.loading--;
    },

    normalizeData(schedulles) {
      schedulles.forEach((e) => (e.data = e.data.split("T")[0]));
    },
  },
};
</script>

<style>
.top-table {
  display: flex;
  justify-content: space-between;
  padding: 20px;
}

.top-table .v-input {
  max-width: 500px;
}

.v-icon {
  margin: 0 10px;
}
</style>