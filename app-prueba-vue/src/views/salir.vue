<template>
    <div class="container">
      <div class="error-card">
        <h1>Sesión finalizada</h1>
        <center>
          <v-img
            src="https://www.krispykreme.mx/wp-content/uploads/2023/05/logo_krispy_kreme.png"
            contain
            width="200"
            height="100"
          />
        </center>
        <div class="actions">
          <v-btn color="primary" @click="goToLogin">🔑 Iniciar Sesión</v-btn>
        </div>
      </div>
    </div>
  </template>
  
  <script>
  export default {
    mounted(){
        localStorage.removeItem("token");
        localStorage.removeItem("nombreUsuario");
        localStorage.removeItem("rol");
    },
    methods: {
      goBack() {
        this.$router.go(-1); // Regresar a la página anterior
      },
      goToLogin() {
        this.$router.push("/"); // Redirigir a la página de login
      },
    },
  };
  </script>
  
  <style scoped>
  .container {
    display: flex;
    justify-content: center;
    align-items: center;
    height: 100vh;
    background-color: #f8f9fa;
  }
  .error-card {
    background: white;
    padding: 30px;
    text-align: center;
    border-radius: 10px;
    box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
  }
  h1 {
    color: #dc3545;
  }
  p {
    margin: 10px 0;
  }
  .actions{
    margin-top: 20px;
  }
  
  </style>
  