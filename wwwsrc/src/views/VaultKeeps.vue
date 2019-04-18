<template>
  <div class="dashboard container-fluid">
    <h1>Vault Keeps</h1>

  </div>


  <!-- :class="$mq | mq({xs: '', sm: '', md: '', lg: ''})" -->


</template>

<script>
  import Vault from "@/components/Vault.vue"
  import Keep from "@/components/Keep.vue"

  export default {
    name: "dashboard",
    mounted() {
      //blocks users not logged in
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "login" });
      }
    },
    data() {
      return {
        newVault: {
        },
        newKeep: {

        }
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
      Keep
    }

  };
</script>