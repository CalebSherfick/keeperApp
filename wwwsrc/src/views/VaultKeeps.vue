<template>
  <div class="dashboard container-fluid">
    <h1>Vault Keeps</h1>
    <h2>{{vault.name}}</h2>

    <section class="row vaults">
      <div class="col-12">
        <vault-keep></vault-keep>
      </div>
    </section>

  </div>


  <!-- :class="$mq | mq({xs: '', sm: '', md: '', lg: ''})" -->


</template>

<script>
  import Vault from "@/components/Vault.vue"
  import VaultKeep from "@/components/VaultKeep.vue"

  export default {
    name: "dashboard",
    props: [],
    mounted() {
      //blocks users not logged in
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "login" });
      }
      //Get vaultkeeps
      this.$store.dispatch('getVaultKeeps', parseInt(this.$route.params.VaultId));
    },
    data() {
      return {
      }
    },
    computed: {
      vault() {
        return this.$store.state.activeVault
      },
      keeps() {
        return this.$store.state.keeps
      }
    },
    methods: {

    },
    components: {
      Vault,
      VaultKeep
    }

  };
</script>