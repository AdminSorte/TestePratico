<template>
  <v-form v-model="valid">
    <v-container>
      <center>
        <v-col cols="12" md="7">
          <v-spacer></v-spacer>
          <v-col>
            <v-text-field
              v-model="user"
              :rules="userRules"
              label="Usuário"
              required
            ></v-text-field>
          </v-col>

          <v-col>
            <v-text-field
              v-model="password"
              :rules="passwordRules"
              label="Senha"
              required
            ></v-text-field>
          </v-col>
          <v-col cols="12" md="7">
            <v-btn text @click="submitLogin">
              Entrar
              <v-progress-circular
                v-if="loading"
                indeterminate
                color="primary"
              ></v-progress-circular>
            </v-btn>
          </v-col>
        </v-col>
      </center>
    </v-container>
  </v-form>
</template>

<script>
import { AgendaApi } from "../api/AgendaApi.js";

export default {
  data: () => ({
    valid: false,
    validForm: false,
    user: "",
    userRules: [(v) => !!v || "Informe o usuário"],
    password: "",
    passwordRules: [(v) => !!v || "Senha é necessária"],
    loading: false,
  }),

  methods: {
    async submitLogin() {
      this.loading = true;

      const resp = await AgendaApi.User.singIn({
        name: this.user.trim(),
        password: this.password.trim(),
      });

      if (resp.status == 400) {
        this.$toasted?.global.error({
          mensagem: "Usuário ou senha incorretos",
        });
        this.loading = false;
        return;
      }

      this.setTokenLocalStorage(resp.accessToken);
      this.$toasted?.global.success({ mensagem: "Login efetuado com sucesso" });

      this.loading = false;

      this.$router.push({ name: "Home" });
    },
    setTokenLocalStorage(token) {
      localStorage.setItem("accessToken", token);
    },
  },
};
</script>

<style>
</style>