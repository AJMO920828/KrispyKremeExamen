// Styles
import "@mdi/font/css/materialdesignicons.css";
import "vuetify/styles";

import localization from "./Localization"; 

// Vuetify
import { createVuetify } from "vuetify";

export default createVuetify({
    locale: {
      locale: "es",
      fallback: "es",
      messages: { es : localization },
    },
    theme: {
      defaultTheme: "customTheme",
      themes: {
        customTheme: {
          dark: false,
          colors: {
            primary: "#006937",
            secondary: "#424242",
            error: "#cf0c2e",
            success: "#4caf50",
            warning: "#ff9800",
            info: "#2196f3",
          },
        },
      },
    },
  });
// https://vuetifyjs.com/en/introduction/why-vuetify/#feature-guides
