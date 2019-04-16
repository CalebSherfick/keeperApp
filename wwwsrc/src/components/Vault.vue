<template>
  <div :class="$mq | mq({xs: 'col-12', sm: 'col-12', md: 'col-4', lg: 'col-3'})">
    <p>{{vault.name}}</p>
    <p>{{vault.description}}</p>
    <button class="btn btn-danger px-4 mb-2" @click="deleteVault(vault.id)">Delete</button>
  </div>
</template>

<script>
export default {
  name: "vault",
  props: ["vault"],
  data() {
    return {};
  },
  computed: {},
  methods: {
    deleteVault(vaultId) {
      this.$store.dispatch("deleteVault", vaultId);
    }
  },
  components: {}
};
</script>