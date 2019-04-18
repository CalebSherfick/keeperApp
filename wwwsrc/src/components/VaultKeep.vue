<template>
  <div :class="$mq | mq({xs: 'col-12', sm: 'col-12', md: '', lg: 'col-3'})">
    <img :src="keep.img" :class="$mq | mq({xs: 'w-100', sm: 'w-100', md: 'w-100', lg: 'w-100'})">
    <p>{{keep.name}}</p>
    <p>{{keep.description}}</p>
    <button class="btn btn-danger px-4 mb-2" @click="deleteVaultKeep(keep.id)">Remove From Vault</button>


  </div>
</template>

<script scoped>
  export default {
    name: "vaultkeep",
    props: ["keep"],
    data() {
      return {};
    },
    computed: {
    },
    methods: {
      deleteVaultKeep(keepId) {
        this.$store.dispatch("deleteVaultKeep", { KeepId: keepId, VaultId: parseInt(this.$route.params.VaultId) });
      }
    },
    components: {
    }
  };
</script>