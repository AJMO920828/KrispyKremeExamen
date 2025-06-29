<template>
    <div class="container">
      <div class="error-card">
        <h1>🚫 No Autorizado</h1>
        <p>No tienes permisos para acceder a esta página.</p>
        <div class="actions">
          <button @click="goToLogin" v-if="!isLoggedIn">🔑 Iniciar Sesión</button>
          <button @click="goBack" v-else>🔙 Volver</button>
        </div>
      </div>
    </div>
  </template>
  
  <script>
  export default {
    name: "NotAuthorized",
    
    computed: {
      isLoggedIn() {
        const rol = localStorage.getItem("rol");
        return rol !== null && rol.trim() !== "" && rol === "Ventas"; // Verifica si el rol es válido y es de tipo admin
      },
    },
    
    methods: {
      goBack() {
        this.$router.push("/ventas") // Regresar a la página de ventas
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
  .actions button {
    margin: 10px;
    padding: 10px 15px;
    border: none;
    border-radius: 5px;
    cursor: pointer;
    font-size: 16px;
  }
  .actions button:first-child {
    background-color: #6c757d;
    color: white;
  }
  .actions button:last-child {
    background-color: #007bff;
    color: white;
  }
  .actions button:hover {
    opacity: 0.8;
  }
  </style>
  