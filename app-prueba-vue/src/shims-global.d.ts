import { ComponentCustomProperties } from "vue";
import alertaDlg from "@/components/alertaDlg.vue";

declare module "@vue/runtime-core" {
  interface ComponentCustomProperties {
    $route: RouteLocationNormalizedLoaded;
    $router: Router;
    $alertaDlg: InstanceType<typeof alertaDlg>;
    $toast: {
      success: (message: string, options?: ToastContainerOptions) => void;
      error: (message: string, options?: ToastContainerOptions) => void;
      info: (message: string, options?: ToastContainerOptions) => void;
      warning: (message: string, options?: ToastContainerOptions) => void;
    };
  }
}