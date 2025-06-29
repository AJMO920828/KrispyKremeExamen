<template>
  <v-dialog v-model="dialog" persistent width="auto">
    <v-card>
      <v-toolbar color="primary" v-if="title">
        <v-toolbar-title>
          <v-icon :color="iconColor" v-if="icon">{{ icon }}</v-icon>
          {{ title }}
        </v-toolbar-title>
        <v-toolbar-items v-if="isClose">
          <v-btn icon dark @click="closeDialog">
            <v-icon>mdi-close</v-icon>
          </v-btn>
        </v-toolbar-items>
      </v-toolbar>
      <v-card-text>
        <div v-html="message"></div>
      </v-card-text>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn color="red-darken-1" variant="text" @click="_cancel" v-if="cancelButton">
          {{ cancelButton }}
        </v-btn>
        <v-btn color="primary" variant="text" @click="_confirm">
          {{ okButton }}
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script lang="ts">
import { defineComponent, ref } from "vue";

export default defineComponent({
  name: "alertaDlg",
  data() {
    return {
      dialog: false,
      title: "Alerta",
      message: "",
      okButton: "Aceptar",
      cancelButton: "",
      isClose: false,
      icon: "mdi-alert-outline",
      iconColor: "orange",
      resolvePromise: undefined as ((value: boolean) => void) | undefined,
    };
  },
  methods: {
    show(opts: {
      titulo?: string;
      mensaje?: string;
      aceptar?: string;
      cancelar?: string;
      icon?: string;
      iconColor?: string;
      isClose?: boolean;
    }) {
      this.title = opts.titulo ?? this.title;
      this.message = opts.mensaje ?? "";
      this.okButton = opts.aceptar ?? "Aceptar";
      this.cancelButton = opts.cancelar ?? "";
      this.icon = opts.icon ?? this.icon;
      this.iconColor = opts.iconColor ?? this.iconColor;
      this.isClose = opts.isClose ?? false;
      this.dialog = true;

      return new Promise<boolean>((resolve) => {
        this.resolvePromise = resolve;
      });
    },
    closeDialog() {
      this.dialog = false;
      if (this.resolvePromise) this.resolvePromise(false);
    },
    _confirm() {
      this.dialog = false;
      if (this.resolvePromise) this.resolvePromise(true);
    },
    _cancel() {
      this.dialog = false;
      if (this.resolvePromise) this.resolvePromise(false);
    },
  },
});
</script>
