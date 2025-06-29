<template>
  <div class="ventas-wrapper py-4">
    <HeaderMenu></HeaderMenu>
    <v-container>
      <v-row>
        <v-col cols="12" md="8" class="mx-auto">
          <v-card elevation="6" class="pa-4">
            <v-card-title>
              <h2 class="mb-0">Ventas</h2>
              <v-spacer></v-spacer>
              <v-btn color="primary" @click="abrirDialogo" prepend-icon="mdi-plus">
                Nueva venta
              </v-btn>
            </v-card-title>
            <v-divider></v-divider>
            <table class="table table-striped table-hover mt-4">
              <thead>
                <tr>
                  <th>ID</th>
                  <th>Producto</th>
                  <th>Monto</th>
                  <th>Fecha</th>
                  <th>Vendedor</th>
                </tr>
              </thead>
              <tbody>
                <tr v-for="venta in ventas" :key="venta.id">
                  <td>{{ venta.id }}</td>
                  <td>{{ venta.descripcion }}</td>
                  <td>${{ Number(venta.monto).toLocaleString() }}</td>
                  <td>{{ formateaFecha(venta.fecha) }}</td>
                  <td>{{ venta.usuarioAlta }}</td>
                </tr>
              </tbody>
            </table>
          </v-card>
        </v-col>
      </v-row>
      <!-- Diálogo de alta de venta -->
      <v-dialog v-model="dialog" max-width="500">
        <v-card>
          <v-toolbar  color="primary" title="Nueva venta">
            <v-spacer></v-spacer>
            <v-toolbar-items>
              <v-btn icon dark @click="cerrarDialogo"> <v-icon>mdi-close</v-icon> </v-btn>
            </v-toolbar-items>
          </v-toolbar>
          <v-card-text>
            <v-form ref="ventaForm" v-model="formValido">
              <v-text-field v-model="nuevaVenta.descripcion" label="Descripción" :rules="[v => !!v || 'El campo es requerido']" required />
              <v-text-field v-model="nuevaVenta.monto" label="Monto" type="number" :rules="[v => v > 0 || 'El monto debe ser mayor a 0']" required />
              <v-text-field v-model="nuevaVenta.fecha" label="Fecha" type="date" :rules="[v => !!v || 'La fecha es requerida']" required />
            </v-form>
          </v-card-text>
          <v-card-actions>
            <v-spacer />
            <v-btn variant="tonal" color="error" @click="cerrarDialogo">Cancelar</v-btn>
            <v-btn color="primary" @click="guardarVenta">Guardar</v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
    </v-container>
  </div>
</template>

<script>
import VentaService from "@/services/venta.service";
import HeaderMenu from "@/components/HeaderMenu.vue";
export default {
  components: {
    HeaderMenu
  },
  data() {
    return {
      dialog: false,
      ventas: [],
      formValido: false,
      guardando: false,
      nuevaVenta: {
        descripcion: '',
        monto: 0,
        fecha: ''
      }
    };
  },
  mounted() {
    this.cargarVentas();
  },
  methods: {
    // Formatea fecha tipo 2024-06-28T00:00:00Z a DD/MM/YYYY
    formateaFecha(fecha) {
      if (!fecha) return '';
      return new Date(fecha).toLocaleDateString();
    },
    abrirDialogo() {
      this.nuevaVenta = { descripcion: '', monto: 0, fecha: '' };
      this.dialog = true;
    },
    cerrarDialogo() {
      this.dialog = false;
    },
    async guardarVenta() {
      // Validar formulario
      const { valid } = await this.$refs.ventaForm.validate();
      if (!valid) {
        return;
      }
      let result = await this.$alertaDlg.show({
      titulo: "¡Advertencia!",
      mensaje: "¿Está seguro de guardar la venta?",
      aceptar: "Aceptar",
      cancelar: "Cancelar",
      icon: "mdi-alert",
      iconColor: "red",
      isClose: false,
      });
      if (result) {
          console.log("✅ Usuario aceptó el guardado de la venta.");
          // Crear venta
          try {
            const resp = await VentaService.guardarVenta({ descripcion: this.nuevaVenta.descripcion, monto: Number(this.nuevaVenta.monto), fecha: this.nuevaVenta.fecha });
            if (resp && resp.id) {
              this.cargarVentas();
              this.cerrarDialogo();
            } 
          } catch (e) {
            toast.error(`No se pudo registrar la venta.`);
          }
      } else {
          console.log("❌ Usuario canceló la acción.");
      }
    },
    async cargarVentas() {
      try {
        const data = await VentaService.getVentas();
        this.ventas = data;
      } catch (e) {
        toast.error(`No se encontraron registros.`);
      } finally {
      }
    }
  }
};
</script>

<style scoped>
.ventas-wrapper {
  min-height: 100vh;
  background: #f4f6fa;
}
.table th,
.table td {
  vertical-align: middle !important;
}
</style>
