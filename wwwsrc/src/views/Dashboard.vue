<template>
  <div class="dashboard container-fluid">
    <h1>Keepr</h1>


    <!-- Button trigger modal -->
    <button type="button" class="btn btn-success" data-toggle="modal" data-target="#createVaultMod">
      Create Vault
    </button>
    <button type="button" class="btn btn-success" data-toggle="modal" data-target="#createKeepMod">
      Create Keep
    </button>


    <!-- Create VAULT Modal -->
    <div class="modal" id="createVaultMod" tabindex="-1" role="dialog" aria-labelledby="createVaultModalLabel"
      aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="createVaultModalLabel">Enter Vault Data</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <form @submit.prevent="createVault">
              <input type="text" placeholder=" Name" v-model="newVault.name" required>
              <input type="text" placeholder=" Description" v-model="newVault.description" class="ml-2" id="desc">
              <button type="submit" class="btn btn-sm btn-outline-dark shadow ml-2">Create Vault</button>
            </form>
          </div>
          <div class="modal-footer">
          </div>
        </div>
      </div>
    </div>


    <!-- Create KEEP Modal -->
    <div class="modal" id="createKeepMod" tabindex="-1" role="dialog" aria-labelledby="createKeepModalLabel"
      aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="createKeepModalLabel">Enter Keep Data</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <form @submit.prevent="createKeep">
              <input type="text" placeholder=" Name" v-model="newKeep.name" required>
              <input type="text" placeholder=" Description" v-model="newKeep.description" class="ml-2" id="desc">
              <input type="text" placeholder=" Image Url" v-model="newKeep.img" class="ml-2" id="desc">
              <button type="submit" class="btn btn-sm btn-outline-dark shadow ml-2">Create Keep</button>
            </form>
          </div>
          <div class="modal-footer">
          </div>
        </div>
      </div>
    </div>









    <section class="row vaults">
      <div class="col-12">
        <div class="row">
          <keep v-for="keep in keeps" :keep="keep"></keep>
          <!-- <vault v-for="vault in vaults" :vault="vault"></vault> -->
        </div>
      </div>
    </section>
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
      this.$store.dispatch('getVaults');
      this.$store.dispatch('getKeeps');
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
      createVault() {
        this.$store.dispatch("createVault", this.newVault);
        event.target.reset();
      },
      createKeep() {
        this.$store.dispatch("createKeep", this.newKeep);
        event.target.reset();
      }

    },
    components: {
      Vault,
      Keep
    }

  };
</script>