<template>
  <div class="dashboard container-fluid">
    <h1>Vault Keeps</h1>

    <section class="row vaults">
      <div class="col-12">
        <div class="row">
          <vault-keep v-for="keep in keeps" :keep="keep"></vault-keep>
        </div>
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
    mounted() {
      //blocks users not logged in
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "login" });
      }
      //Get vault where vaultid= params & userid=logged in

      //Get vaultkeeps
      this.$store.dispatch('getVaultKeeps', parseInt(this.$route.params.VaultId));
    },
    data() {
      return {
      }
    },
    computed: {
      vaults() {
        return this.$store.state.myVaults
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