<template>
    <HeaderMenu />
  <v-container>
    <v-card>
      <v-card-title>
        Lista de Usuarios
        <v-spacer />
        <v-btn color="primary" @click="abrirDialogo">Nuevo Usuario</v-btn>
      </v-card-title>

      <v-data-table :headers="headers" :items="usuarios" class="elevation-1">
        <template v-slot:item.activo="{ item }">
          <v-chip :color="item.activo ? 'green' : 'red'" dark>
            {{ item.activo ? 'Activo' : 'Inactivo' }}
          </v-chip>
        </template>
      </v-data-table>
    </v-card>

    <v-dialog v-model="dialogo" min-width="400px" max-width="1000px">
      <v-card>
        <v-toolbar color="primary" dark>
          <v-toolbar-title>Nuevo Usuario</v-toolbar-title>
          <v-spacer />
          <v-btn icon @click="cerrarDialogo">
            <v-icon>mdi-close</v-icon>
          </v-btn>
        </v-toolbar>

        <v-card-text>
          <v-form ref="form" v-model="formValido">
            <v-row>
              <v-col cols="12" sm="6" md="4">
                <v-text-field v-model="nuevoUsuario.nombre" label="Nombre" :rules="[v => !!v || 'Requerido']" required />
              </v-col>
              <v-col cols="12" sm="6" md="4">
                <v-text-field v-model="nuevoUsuario.usuario" label="Usuario" :rules="[v => !!v || 'Requerido']" required />
              </v-col>
              <v-col cols="12" sm="6" md="4">
                <v-text-field v-model="nuevoUsuario.correo" label="Correo" :rules="[v => !!v || 'Requerido']" required />
              </v-col>
              <v-col cols="12" sm="6" md="4">
                <v-text-field v-model="nuevoUsuario.rol" label="Rol" :rules="[v => !!v || 'Requerido']" required />
              </v-col>
              <v-col cols="12" sm="6" md="4">
                <v-text-field v-model="nuevoUsuario.contrasena" label="Contraseña" type="password" :rules="[v => !!v || 'Requerido']" required />
              </v-col>
            </v-row>
          </v-form>
        </v-card-text>

        <v-card-actions>
          <v-spacer />
          <v-btn color="error" variant="tonal" @click="cerrarDialogo">Cancelar</v-btn>
          <v-btn color="primary" :loading="guardando" @click="guardarUsuario">Guardar</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-container>
</template>

<script>
import UsuarioService from '@/services/usuario.service'; 
import HeaderMenu from '@/components/HeaderMenu.vue';
export default {
  name: 'Usuarios',
  components: {
    HeaderMenu
  },
  data() {
    return {
      usuarios: [],
      dialogo: false,
      form: null,
      formValido: false,
      guardando: false,
      nuevoUsuario: {
        nombre: '',
        usuario: '',
        correo: '',
        contrasena: '',
        rol: ''
      },
      headers: [
        { title: 'ID', key: 'id' },
        { title: 'Nombre', key: 'nombre' },
        { title: 'Usuario', key: 'usuarioNombre' },
        { title: 'Correo', key: 'correo' },
        { title: 'Rol', key: 'rol' },
        { title: 'Activo', key: 'activo' }
      ]
    };
  },
  mounted() {
    this.cargarUsuarios();
  },
  methods: {
    async cargarUsuarios() {
      try {
        let users = await UsuarioService.obtenerUsuarios();
        this.usuarios = users;
      } catch (e) {
        toast.error('Error al cargar usuarios.');
      }
    },
    abrirDialogo() {
      this.dialogo = true;
      this.nuevoUsuario = {
        nombre: '',
        usuario: '',
        correo: '',
        contrasena: '',
        rol: ''
      };
    },
    cerrarDialogo() {
      this.dialogo = false;
    },
    async guardarUsuario() {
      const { valid } = await this.$refs.form.validate();
      if (!valid) {
        return;
      }

      let result = await this.$alertaDlg.show({
      titulo: "¡Advertencia!",
      mensaje: "¿Está seguro de guardar al usuario?",
      aceptar: "Aceptar",
      cancelar: "Cancelar",
      icon: "mdi-alert",
      iconColor: "red",
      isClose: false,
      });
      if (result) {
          try {
            await UsuarioService.crearUsuario(this.nuevoUsuario);
            toast.success('Usuario creado exitosamente.');
            this.cerrarDialogo();
            this.cargarUsuarios();
        } catch (e) {
            toast.error('Error al crear el usuario.');
        } 
      } else {
          console.log("❌ Usuario canceló la acción.");
      }

      
    }
  }
};
</script>
