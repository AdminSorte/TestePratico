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
              :counter="5"
              label="Senha"
              required
            ></v-text-field>
          </v-col>
          <v-col cols="12" md="7">
            <v-btn  text @click="submitLogin"> 
                Entrar 
            </v-btn>
            <v-spacer></v-spacer>
            <v-btn  text @click="submitSignup"> 
                Cadastrar 
            </v-btn>
          </v-col>
        </v-col>
      </center>
    </v-container>
  </v-form>
</template>

<script>
export default {
  data: () => ({
    valid: false,
    user: "",
    userRules: [
      (v) => !!v || "Informe o usuário",
    ],
    password: "",
    passwordRules: [
        (v) => !!v || "Senha é necessária",
        (v) => v.length <= 5 || "Senha deve ter ao menos 5 caracteres",
    ],
  }),

  methods: {
    submitLogin() {
        if(this.valid){
            localStorage.setItem('user', this.user);
            localStorage.setItem('password', this.password);
        }
        console.log(this.user);
    },

    submitSignup() {
        console.log(this.password)
    },
  },
};
</script>

<style>
</style>