<template>
  <div class="home">
    <h1>Welcome Home</h1>
    <form @submit.prevent="createVault">
      <input type="text" placeholder=" Name" v-model="newVault.name" required>
      <input type="text" placeholder=" Description" v-model="newVault.description" class="ml-2" id="desc">
      <button type="submit" class="btn btn-sm btn-outline-dark shadow ml-2">Create Vault</button>
    </form>

  </div>
</template>

<script>
  export default {
    name: "home",
    mounted() {
      //blocks users not logged in
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "login" });
      }
      dispatch('getVaults')
    },
    data() {
      return {
        newVault: {
        }
      }
    },
    methods: {
      createVault() {
        this.$store.dispatch("createVault", this.newVault);
        // this.newVault = { title: "", description: "" };
        event.target.reset()

      }

    }
  };
</script>