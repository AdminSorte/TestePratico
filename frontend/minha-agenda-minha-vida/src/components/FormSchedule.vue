<template>
  <div>
    <v-card-text>
      <v-container>
        <v-row>
          <v-col cols="12">
            <v-text-field
              v-model="schedule.titulo"
              label="Título"
              :readonly="isReadonly"
            ></v-text-field>
          </v-col>
          <v-col cols="12">
            <v-text-field
              v-model="schedule.descricao"
              label="Descrição"
              :readonly="isReadonly"
            ></v-text-field>
          </v-col>
          <v-col cols="12">
            <v-text-field
              v-model="schedule.data"
              label="Data da agenda"
              type="date"
              :readonly="isReadonly"
            ></v-text-field>
          </v-col>
        </v-row>
      </v-container>
    </v-card-text>

    <v-card-actions v-if="!isReadonly">
      <v-spacer></v-spacer>
      <v-btn color="blue darken-1" text @click="save()"> Salvar </v-btn>
    </v-card-actions>
    <!-- / Formulário de edição / criação da agenda -->
  </div>
</template>

<script>
import { AgendaApi } from "../api/AgendaApi.js";

export default {
  props: {
    scheduleReceived: Object,
    reloadSchedules: Function,
    isReadonly: Boolean,
  },
  data: () => ({
    schedule: {},
  }),

  created() {
    this.schedule = this.scheduleReceived ?? {};
  },

  methods: {
    async save() {
      const resp = this.scheduleReceived
        ? await AgendaApi.Agenda.update({ ...this.schedule })
        : await AgendaApi.Agenda.create({ ...this.schedule });

      if (!resp) {
        this.$toasted?.global.error({ mensagem: "Erro ao salvar a agenda" });
        return;
      }

      this.$toasted?.global.success({ mensagem: "Agenda salva com sucesso" });
      this.reloadSchedules();
    },
  },
};
</script>

<style>
</style>