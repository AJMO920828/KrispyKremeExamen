<template>
  <v-app>
    
    <alertaDlg ref="alertaDlgRef" />
    <v-main>
      <router-view />
      <v-dialog v-model="cargando" persistent width="300" content-class="loaderDialog">
        <div class="loader">
        </div>
      </v-dialog>
    </v-main>
  </v-app>
</template>

<script lang="ts">
import { defineComponent, ref, onMounted, getCurrentInstance, computed } from "vue";
import { useStore } from "vuex";
import axios from "axios";
import { toast } from "vue3-toastify";
import alertaDlg from "@/components/alertaDlg.vue";
import HeaderMenu from "@/components/HeaderMenu.vue";
import router from "@/router";

export default defineComponent({
  components: { alertaDlg, HeaderMenu },
  setup() {
    const alertaDlgRef = ref<InstanceType<typeof alertaDlg> | null>(null);
    const instance = getCurrentInstance();
    const store = useStore();

    const cargando = computed(() => store.state.loading.isLoading);

    onMounted(() => {
      if (alertaDlgRef.value && instance) {
        instance.appContext.config.globalProperties.$alertaDlg = alertaDlgRef.value;
      }
    });

    axios.interceptors.request.use(
      (config) => {
        if (config.headers.loading) {
          store.commit('loading', true);
        }
        return config;
      }, (error) => {
        store.commit('loading', false);
        return Promise.reject(error);
      }
    );

    axios.interceptors.response.use(
      (response) => {
        if (response.config.headers.loading) { 
          store.commit('loading', false); 
        }
        if ( response.data && typeof response.data === "object" && "success" in response.data && "httpStatus" in response.data && "messageResponse" in response.data && "body" in response.data) {
          if(response.data.success) {
            return response.data.body;
          } else {
            toast.error(`Mensaje: ${response.data.messageResponse}`);
            return Promise.reject(new Error("La respuesta del servidor es incorrecta."));
          }
          
        }
        toast.error(`La respuesta es incorrecta.`);
        console.error(`La respuesta es incorrecta: \n ${JSON.stringify(response.data, null, 2)}`)
        return Promise.reject(new Error("La respuesta del servidor es incorrecta."));
      }, (error) => {
        if (error.response && (error.response.status === 401 || error.response.status === 403)) {
          router.push("/no-autorizado");
        }
        store.commit('loading', false);
        return Promise.reject(error);
      }
    );
    return { alertaDlgRef, cargando };
  },
});
</script>
<style>



/**Loader */
.v-dialog.loaderDialog  {
  box-shadow: none;
}
.loader {
  font-size: 20px;
  margin: 45% auto;
  width: 1em;
  height: 1em;
  border-radius: 50%;
  position: relative;
  text-indent: -9999em;
  -webkit-animation: load4 1.3s infinite linear;
  animation: load4 1.3s infinite linear;
}
@-webkit-keyframes load4 {
  0%,
  100% {
    box-shadow: 0em -3em 0em 0.2em #006938, 2em -2em 0 0em #006938, 3em 0em 0 -0.5em #006938, 2em 2em 0 -0.5em #006938, 0em 3em 0 -0.5em #006938, -2em 2em 0 -0.5em #006938, -3em 0em 0 -0.5em #006938, -2em -2em 0 0em #006938;
  }
  12.5% {
    box-shadow: 0em -3em 0em 0em #006938, 2em -2em 0 0.2em #006938, 3em 0em 0 0em #006938, 2em 2em 0 -0.5em #006938, 0em 3em 0 -0.5em #006938, -2em 2em 0 -0.5em #006938, -3em 0em 0 -0.5em #006938, -2em -2em 0 -0.5em #006938;
  }
  25% {
    box-shadow: 0em -3em 0em -0.5em #006938, 2em -2em 0 0em #006938, 3em 0em 0 0.2em #006938, 2em 2em 0 0em #006938, 0em 3em 0 -0.5em #006938, -2em 2em 0 -0.5em #006938, -3em 0em 0 -0.5em #006938, -2em -2em 0 -0.5em #006938;
  }
  37.5% {
    box-shadow: 0em -3em 0em -0.5em #006938, 2em -2em 0 -0.5em #006938, 3em 0em 0 0em #006938, 2em 2em 0 0.2em #006938, 0em 3em 0 0em #006938, -2em 2em 0 -0.5em #006938, -3em 0em 0 -0.5em #006938, -2em -2em 0 -0.5em #006938;
  }
  50% {
    box-shadow: 0em -3em 0em -0.5em #006938, 2em -2em 0 -0.5em #006938, 3em 0em 0 -0.5em #006938, 2em 2em 0 0em #006938, 0em 3em 0 0.2em #006938, -2em 2em 0 0em #006938, -3em 0em 0 -0.5em #006938, -2em -2em 0 -0.5em #006938;
  }
  62.5% {
    box-shadow: 0em -3em 0em -0.5em #006938, 2em -2em 0 -0.5em #006938, 3em 0em 0 -0.5em #006938, 2em 2em 0 -0.5em #006938, 0em 3em 0 0em #006938, -2em 2em 0 0.2em #006938, -3em 0em 0 0em #006938, -2em -2em 0 -0.5em #006938;
  }
  75% {
    box-shadow: 0em -3em 0em -0.5em #006938, 2em -2em 0 -0.5em #006938, 3em 0em 0 -0.5em #006938, 2em 2em 0 -0.5em #006938, 0em 3em 0 -0.5em #006938, -2em 2em 0 0em #006938, -3em 0em 0 0.2em #006938, -2em -2em 0 0em #006938;
  }
  87.5% {
    box-shadow: 0em -3em 0em 0em #006938, 2em -2em 0 -0.5em #006938, 3em 0em 0 -0.5em #006938, 2em 2em 0 -0.5em #006938, 0em 3em 0 -0.5em #006938, -2em 2em 0 0em #006938, -3em 0em 0 0em #006938, -2em -2em 0 0.2em #006938;
  }
}
@keyframes load4 {
  0%,
  100% {
    box-shadow: 0em -3em 0em 0.2em #ff3323, 2em -2em 0 0em #006938, 3em 0em 0 -0.5em #ff3323, 2em 2em 0 -0.5em #006938, 0em 3em 0 -0.5em #ff3323, -2em 2em 0 -0.5em #006938, -3em 0em 0 -0.5em #ff3323, -2em -2em 0 0em #006938;
  }
  12.5% {
    box-shadow: 0em -3em 0em 0em #ff3323, 2em -2em 0 0.2em #006938, 3em 0em 0 0em #ff3323, 2em 2em 0 -0.5em #006938, 0em 3em 0 -0.5em #ff3323, -2em 2em 0 -0.5em #006938, -3em 0em 0 -0.5em #ff3323, -2em -2em 0 -0.5em #006938;
  }
  25% {
    box-shadow: 0em -3em 0em -0.5em #ff3323, 2em -2em 0 0em #006938, 3em 0em 0 0.2em #ff3323, 2em 2em 0 0em #006938, 0em 3em 0 -0.5em #ff3323, -2em 2em 0 -0.5em #006938, -3em 0em 0 -0.5em #ff3323, -2em -2em 0 -0.5em #006938;
  }
  37.5% {
    box-shadow: 0em -3em 0em -0.5em #ff3323, 2em -2em 0 -0.5em #006938, 3em 0em 0 0em #ff3323, 2em 2em 0 0.2em #006938, 0em 3em 0 0em #ff3323, -2em 2em 0 -0.5em #006938, -3em 0em 0 -0.5em #ff3323, -2em -2em 0 -0.5em #006938;
  }
  50% {
    box-shadow: 0em -3em 0em -0.5em #ff3323, 2em -2em 0 -0.5em #006938, 3em 0em 0 -0.5em #ff3323, 2em 2em 0 0em #006938, 0em 3em 0 0.2em #ff3323, -2em 2em 0 0em #006938, -3em 0em 0 -0.5em #ff3323, -2em -2em 0 -0.5em #006938;
  }
  62.5% {
    box-shadow: 0em -3em 0em -0.5em #ff3323, 2em -2em 0 -0.5em #006938, 3em 0em 0 -0.5em #ff3323, 2em 2em 0 -0.5em #006938, 0em 3em 0 0em #ff3323, -2em 2em 0 0.2em #006938, -3em 0em 0 0em #ff3323, -2em -2em 0 -0.5em #006938;
  }
  75% {
    box-shadow: 0em -3em 0em -0.5em #ff3323, 2em -2em 0 -0.5em #006938, 3em 0em 0 -0.5em #ff3323, 2em 2em 0 -0.5em #006938, 0em 3em 0 -0.5em #ff3323, -2em 2em 0 0em #006938, -3em 0em 0 0.2em #ff3323, -2em -2em 0 0em #006938;
  }
  87.5% {
    box-shadow: 0em -3em 0em 0em #ff3323, 2em -2em 0 -0.5em #006938, 3em 0em 0 -0.5em #ff3323, 2em 2em 0 -0.5em #006938, 0em 3em 0 -0.5em #ff3323, -2em 2em 0 0em #006938, -3em 0em 0 0em #ff3323, -2em -2em 0 0.2em #006938;
  }
}
</style>


