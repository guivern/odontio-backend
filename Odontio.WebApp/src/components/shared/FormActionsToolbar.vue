<template>
  <v-card flat class="mb-4" color="white" :disabled="disabled">
    <v-card-title class="d-flex align-center">
      <v-slide-group show-arrows>
        <v-slide-group-item>
          <toggle-read-mode
            v-if="showReadModeBtn"
            @input="$emit('update:modelValue', $event.target.checked)"
            v-bind="{
              ...$attrs,
              modelValue
            }"
          ></toggle-read-mode>
          <slot></slot>
          <v-btn
            v-if="showDeleteBtn"
            @click="$emit('on:delete')"
            title="Eliminar"
            append-icon="mdi-delete"
            variant="text"
          >
            Eliminar
          </v-btn>
        </v-slide-group-item>
      </v-slide-group>
    </v-card-title>
  </v-card>
</template>
<script setup>
const props = defineProps({
  showDeleteBtn: {
    type: Boolean,
    default: true
  },
  showReadModeBtn: {
    type: Boolean,
    default: true
  },
  modelValue: {
    type: Boolean,
    default: false
  },
  disabled: {
    type: Boolean,
    default: false
  }
});
</script>
