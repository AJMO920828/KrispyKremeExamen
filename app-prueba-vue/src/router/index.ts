import { createRouter, createWebHashHistory, RouteRecordRaw } from "vue-router";
import ventas from "../views/ventas.vue"
import login from "../views/login.vue"


const routes: Array<RouteRecordRaw> = [
  {
    path: "/",
    name: "home",
    component: login,
  },
  {
    path: "/ventas",
    name: "ventas",
    component: ventas,
  },
  {
    path: "/altaUsuario",
    name: "altaUsuario",
    component: () => import("../views/altaUsuario.vue"),
  },
  {
    path: "/salir",
    name: "salir",
    component: () => import("../views/salir.vue"),
  },
  {
    path: "/no-autorizado",
    name: "NotAuthorized",
    component: () => import("../views/NotAuthorized.vue"),
  }
  

];

const router = createRouter({
  history: createWebHashHistory(),
  routes,
});

export default router;
