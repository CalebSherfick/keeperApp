<template>
  <div class="home container-fluid">
    <h1>All Vaults</h1>
    <form @submit.prevent="createVault">
      <input type="text" placeholder=" Name" v-model="newVault.name" required>
      <input type="text" placeholder=" Description" v-model="newVault.description" class="ml-2" id="desc">
      <button type="submit" class="btn btn-sm btn-outline-dark shadow ml-2">Create Vault</button>
    </form>

    <section class="row vaults">
      <div class="col-12">
        <div class="row">
          <vault v-for="vault in vaults" :vault="vault"></vault>
        </div>
      </div>
    </section>

  </div>


  <!-- :class="$mq | mq({xs: '', sm: '', md: '', lg: ''})" -->


</template>

<script>
  import Vault from "@/components/Vault.vue"

  export default {
    name: "home",
    mounted() {
      //blocks users not logged in
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "login" });
      }
      this.$store.dispatch('getVaults')
    },
    data() {
      return {
        newVault: {
        }
      }
    },
    computed: {
      vaults() {
        return this.$store.state.myVaults
      }
    },
    methods: {
      createVault() {
        this.$store.dispatch("createVault", this.newVault);
        event.target.reset();

      }

    },
    components: {
      Vault
    }

  };
</script>