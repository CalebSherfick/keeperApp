<template>

  <div @click="vaultKeeps(vault.id)"
    :class="$mq | mq({xs: 'col-12 mb-3 clickable', sm: 'col-12 mb-3 clickable', md: 'col-4 mb-3 clickable', lg: 'col-3 mb-3 clickable'})">
    <div class="card">
      <div class="card-header">
        {{vault.name}}
      </div>
      <div class="card-body">
        <p class="card-text">{{vault.description}}</p>
      </div>
      <button class="btn btn-danger px-4" @click="deleteVault(vault.id)">Delete</button>
    </div>
  </div>

</template>

<script scoped>
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
      },
      vaultKeeps(id) {
        debugger
        this.$router.push({
          path: "/vaults/" + id + "/keeps"
        })
      }

    },
    components: {}
  };
</script>

<style>
  .clickable:hover {
    cursor: pointer;
  }
</style>