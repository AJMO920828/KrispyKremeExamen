<template>
    <v-app-bar app color="primary" dense>
      <!-- Botón de menú lateral en móviles -->
      <v-app-bar-nav-icon @click="drawer = !drawer"></v-app-bar-nav-icon>
  
      <!-- Título o logo -->
      <v-toolbar-title>krispy kreme</v-toolbar-title>
  
      <v-spacer></v-spacer>
      <span class="text-h6 mr-4">Bienvenido: {{ nombreUsuario }}</span>

      <!-- Opciones de usuario -->
      <v-menu offset-y>
        <template v-slot:activator="{ props }">
          
        </template>
  
        <v-list>
          <v-list-item v-for="option in userOptions" :key="option.title" @click="option.action">
            <v-list-item-title>{{ option.title }}</v-list-item-title>
          </v-list-item>
        </v-list>
      </v-menu>
    </v-app-bar>
  
    <!-- Menú lateral -->
    <v-navigation-drawer v-model="drawer" temporary>
      <v-list>
        <v-list-item v-for="item in menuItems" :key="item.title" :to="item.route">
          <v-list-item-title>{{ item.title }}</v-list-item-title>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
  </template>
  
  <script lang="ts">
  import { defineComponent, ref } from "vue";
  import { useRouter } from "vue-router";
  
  export default defineComponent({
    name: "HeaderMenu",
    setup() {
      const drawer = ref(false);
      const router = useRouter();
      const nombreUsuario: string = localStorage.getItem("nombreUsuario") ?? "Invitado";
      let userRole: string = localStorage.getItem("rol") ?? "";
      const allMenuItems = [
        { title: "AltaUsuario", route: "/altaUsuario", roles: ["Admin"] },
        { title: "Ventas", route: "/ventas" },
        { title: "Salir", route: "/salir" },
      ];

      const menuItems = ref(
        allMenuItems.filter(item => {
          if (!item.roles) return true; // sin restricción de rol
          return item.roles.includes(userRole);
        })
      );
      const userOptions = ref([
        { title: "Perfil", action: () => router.push("/perfil") },
      ]);
  
  
      return { drawer, menuItems, userOptions, nombreUsuario };
    },
  });
  </script>
  