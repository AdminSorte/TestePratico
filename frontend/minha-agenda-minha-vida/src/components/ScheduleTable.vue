<template>
  <v-card>

    <v-data-table
      :headers="headers"
      :items="desserts"
      :search="search"
      sort-by="calories"
      class="elevation-1"
    >

      <template v-slot:top>

        <v-toolbar flat>

          <!-- Barra depesquisa -->
          <v-text-field
            v-model="search"
            append-icon="mdi-magnify"
            label="Search"
            single-line
            hide-details
          ></v-text-field>
          <!-- / Barra depesquisa -->

          <v-divider class="mx-4" inset vertical></v-divider>

          <v-spacer></v-spacer>

          <!-- Modal novo item -->
          <v-dialog v-model="dialog" max-width="500px">

            <!-- Botão novo item -->
            <template v-slot:activator="{ on, attrs }">
              <v-btn color="primary" dark class="mb-2" v-bind="attrs" v-on="on">
                New Item
              </v-btn>
            </template>
            <!-- / Botão novo item -->

            <!-- Conteudo do modal novo item -->
            <v-card>
              <v-card-title>
                <span class="headline">{{ formTitle }}</span>
              </v-card-title>

              <!-- Formulário de edição / criação da agenda -->
              <v-card-text>
                <v-container>
                  <v-row>
                    <v-col cols="12">
                      <v-text-field
                        v-model="editedItem.title"
                        label="Título"
                        :readonly="readonly"
                      ></v-text-field>
                    </v-col>
                    <v-col cols="12">
                      <v-text-field
                        v-model="editedItem.description"
                        label="Descrição"
                        :readonly="readonly"
                      ></v-text-field>
                    </v-col>
                    <v-col cols="12">
                      <v-text-field
                        v-model="editedItem.date"
                        label="Data da agenda"
                        type="date"
                        :readonly="readonly"
                      ></v-text-field>
                    </v-col>
                  </v-row>
                </v-container>
              </v-card-text>

              <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="blue darken-1" text @click="close">
                  Cancel
                </v-btn>
                <v-btn color="blue darken-1" text @click="save"> 
                  Save 
                </v-btn>
              </v-card-actions>
              <!-- / Formulário de edição / criação da agenda -->

            </v-card>
            <!-- / Conteudo do modal novo item -->


          </v-dialog>
          <!-- / Modal novo item -->

          <!-- Modal deletar -->
          <v-dialog v-model="dialogDelete" max-width="500px">
            <v-card>
              <v-card-title class="headline">
                Are you sure you want to delete this item?
              </v-card-title>
              <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="blue darken-1" text @click="closeDelete">
                  Cancel
                </v-btn>
                <v-btn color="blue darken-1" text @click="deleteItemConfirm">
                  OK
                </v-btn>
                <v-spacer></v-spacer>
              </v-card-actions>
            </v-card>
          </v-dialog>
          <!-- / Modal deletar -->

        </v-toolbar>

      </template>
      <div>
        "tent"
      </div>

      <!-- Ações  -->
      <template v-slot:item.actions="{ item }">
        <v-icon small class="mr-2" @click="editItem(item, true)"> mdi-eye-outline </v-icon>
        <v-icon small class="mr-2" @click="editItem(item)"> mdi-pencil </v-icon>
        <v-icon small @click="deleteItem(item)"> mdi-delete </v-icon>
      </template>
      <!-- / Ações  -->

    </v-data-table>
  </v-card>
</template>

<script>
export default {
  
  data: () => ({
    dialog: false,
    dialogDelete: false,
    search: "",
    readonly: false,
    headers: [
      { text: "Id", sortable: true, value: "id" },
      { text: "Titulo", value: "titulo" },
      { text: "Ações", value: "actions" },
    ],
    desserts: [],
    teste: "",
    editedIndex: -1,
    editedItem: {
      name: "",
      calories: 0,
      fat: 0,
      carbs: 0,
      protein: 0,
    },
    defaultItem: {
      name: "",
      calories: 0,
      fat: 0,
      carbs: 0,
      protein: 0,
    },
  }),

  computed: {
    formTitle() {
      return this.editedIndex === -1 ? "Novo item" : "Editar item";
    },
  },

  watch: {
    dialog(val) {
      val || this.close();
    },
    dialogDelete(val) {
      val || this.closeDelete();
    },
  },

  created() {
    this.initialize();
  },

  methods: {
    async initialize() {
      // CHAMADA NA API E RECEBE OS ITEMS
      // const resp = await APi.getAgendas();
      // this.desserts = resp.data;
      
      // const url = "https://localhost:5001/agenda";
       fetch("https://localhost:5001/agenda", {method: 'GET', mode: 'cors'})
        .then(response => response.json())
        .then(json => this.desserts = json)
      
      // this.desserts = [
      //   {
      //     id: "1",
      //     title: "titulooo 1",
      //     description: "Agendaaaa 1",
      //   },
      //   {
      //     id: "2",
      //     title: "titulooo 2",
      //     description: "Agendaaaa 2",
      //   },
      // ];
    },

    editItem(item, readonly) {
      this.editedIndex = this.desserts.indexOf(item);
      this.editedItem = Object.assign({}, item);
      // CHAMADA NA API para alterar os itens
      // const resp = await APi.deleteAgenda();
      // recarrega os itens e exibe um pupup

      this.readonly = readonly;
      this.dialog = true;
    },

    deleteItem(item) {
      this.editedIndex = this.desserts.indexOf(item);
      this.editedItem = Object.assign({}, item);
      this.dialogDelete = true;
    },

    deleteItemConfirm() {
      // CHAMADA NA API para deletar o item
      // const resp = await APi.deleteAgenda();
      // recarrega os itens e exibe um pupup
      this.desserts.splice(this.editedIndex, 1);
      this.closeDelete();
    },

    close() {
      this.dialog = false;
      this.$nextTick(() => {
        this.editedItem = Object.assign({}, this.defaultItem);
        this.editedIndex = -1;
      });
    },

    closeDelete() {
      this.dialogDelete = false;
      this.$nextTick(() => {
        this.editedItem = Object.assign({}, this.defaultItem);
        this.editedIndex = -1;
      });
    },

    save() {
      if (this.editedIndex > -1) {
        Object.assign(this.desserts[this.editedIndex], this.editedItem);
      } else {
        this.desserts.push(this.editedItem);
      }
      this.close();
    },
  },
};
</script>

<style>
</style>