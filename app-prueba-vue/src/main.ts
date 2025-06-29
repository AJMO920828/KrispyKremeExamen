import { createApp, ref  } from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import vuetify from "./plugins/vuetify";
import { loadFonts } from "./plugins/webfontloader";
import Vue3Toastify, { type ToastContainerOptions, toast} from "vue3-toastify";
import "vue3-toastify/dist/index.css";


// Bootstrap CSS
import 'bootstrap/dist/css/bootstrap.css'
// BootstrapVue3 CSS
import 'bootstrap-vue-3/dist/bootstrap-vue-3.css'

import BootstrapVue3 from 'bootstrap-vue-3'



const toastOptions: ToastContainerOptions = {
    autoClose: 3000,
    position: "top-right",
    theme: "light",
    pauseOnHover: true,
    closeOnClick: true,
};

loadFonts();

const app = createApp(App);
app.use(router)
app.use(store)
app.use(vuetify)
app.use(BootstrapVue3)
app.use(Vue3Toastify, toastOptions)

app.mount("#app")

app.config.globalProperties.$toast = toast;
