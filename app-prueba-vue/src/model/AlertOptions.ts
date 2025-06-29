interface AlertOptions {
    visible: boolean;
    title: string;
    mensaje: string;
    type: "success" | "info" | "warning" | "error";
    variant?: "flat" | "text" | "elevated" | "tonal" | "outlined" | "plain";
    border?: "top" | "bottom" | "start" | "end";
  }
  