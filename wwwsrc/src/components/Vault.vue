<template>
  <div class="col">
    <p>{{vault.name}}</p>
    <button class="btn btn-outline-primary px-4 mb-2" @click="deleteVault(vault.id)">Delete</button>
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