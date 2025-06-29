<template>
  <div class="login-wrapper d-flex justify-content-center align-items-center">
    <div class="login-box shadow">
      <h2 class="text-center mb-4">Bienvenido</h2>
      <center>
        <v-img
          src="https://www.krispykreme.mx/wp-content/uploads/2023/05/logo_krispy_kreme.png"
          class="mb-4"
          contain
          width="200"
          height="100"
        />
      </center>
      <v-form @submit.prevent="handleLogin" ref="loginForm" lazy-validation>
        <div class="mb-3">
          <v-text-field
            v-model="username"
            label="Usuario"
            prepend-inner-icon="mdi-account"
            outlined
            dense
            hide-details="auto"
            :rules="[v => !!v || 'El usuario es requerido']"
            class="login-field"
          />
        </div>
        <div class="mb-3">
          <v-text-field
            v-model="password"
            label="Contraseña"
            prepend-inner-icon="mdi-lock"
            :append-inner-icon="verPassword ? 'mdi-eye' : 'mdi-eye-off'"
            @click:append-inner="verPassword = !verPassword"
            :type="verPassword ? 'text' : 'password'"
            outlined
            dense
            hide-details="auto"
            :rules="[v => !!v || 'La contraseña es requerida']"
            class="login-field"
          />
        </div>
        <v-btn
          type="submit"
          color="primary"
          class="w-100 login-btn"
        >
          Entrar
        </v-btn>
        <div v-if="errorMessage" class="alert alert-danger mt-3" role="alert">
          {{ errorMessage }}
        </div>
      </v-form>
    </div>
  </div>
</template>

<script>
import LoginService from "@/services/login.service";
import router from "@/router";
export default {
  data() {
    return {
      username: "",
      password: "",
      errorMessage: "",
      verPassword: false,
    };
  },
  methods: {
    handleLogin() {
      this.errorMessage = "";
      try {
        if (!(this.username && this.password)) {
          this.errorMessage = "Debes ingresar usuario y contraseña";
          return;
        }

        LoginService.login(this.username, this.password).then(response => {
          if(response.token) {
              localStorage.setItem("token", response.token);
              localStorage.setItem("nombreUsuario", response.nombre);
              localStorage.setItem("rol", response.rol);

              router.push('/ventas');
          }
              
          })
          .catch(error => {
            this.errorMessage = error.message || "Error al iniciar sesión";
          });
      } catch (e) {
        this.errorMessage = e.message;
      }
    },
  },
};
</script>

<style scoped>
.login-wrapper {
  min-height: 100vh;
  background: #eaf0f6;
}
.login-box {
  width: 100%;
  min-width: 300px;
  max-width: 480px;
  min-height: 340px;
  background: #fff;
  border-radius: 20px;
  padding: 2.2rem 2.2rem 2rem 2.2rem;
  display: flex;
  flex-direction: column;
  justify-content: center;
}
@media (max-width: 600px) {
  .login-box {
    max-width: 98vw;
    min-width: 0;
    padding: 1.2rem 0.7rem 1.2rem 0.7rem;
  }
}
.login-field input {
  font-size: 1.15rem;
}
.login-btn {
  font-size: 1.1rem;
  text-transform: none;
  letter-spacing: normal;
}
</style>
