<template>
  <v-dialog v-model="dialog" :width="width">
    <template v-slot:activator="{ on, attrs }">
      <div v-bind="attrs" v-on="on">
        <slot name="clickable" />
      </div>
    </template>

    <v-card id="modal1">
      <v-card-title v-if="title">
        <span class="headline mx-auto">{{ title }}</span>
      </v-card-title>

      <v-card-text class="content" :style="'min-height:' + minHeigth">
        <v-icon v-if="isIconCloseContent" class="close" @click="dialog = false"
          >mdi-close-circle-outline</v-icon
        >
        <slot name="content" />
      </v-card-text>

      <v-divider></v-divider>

      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn color="primary" text @click="dialog = false">Fechar</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script>
export default {
  props: {
    title: String,
    width: String,
    isIconCloseContent: {
      default: false,
      type: Boolean,
    },
    minHeigth: {
      default: "70vh",
      type: String,
    },
    closeModal: Boolean,
  },
  data() {
    return {
      dialog: false,
    };
  },
  watch: {
    closeModal() {
        console.log("fFecharrrrrrrrr");
      this.dialog = false;
    },
  },
};
</script>

<style>
#modal1 .close {
  position: absolute;
  top: 20px;
  right: 20px;
}
</style>