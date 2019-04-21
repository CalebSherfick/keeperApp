<template>
  <div class="vaultsView container-fluid">
    <h1 class="view-title">My Vaults</h1>

    <section class="row vaults">
      <div class="col-12">
        <vault></vault>
      </div>
    </section>

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
              <input type="text" placeholder=" Name" v-model="newVault.name" class="form-input" required>
              <input type="text" placeholder=" Description" v-model="newVault.description" class="form-input mt-3"
                id="desc" required>
              <button type="submit" class="btn form-btn mt-3">Create
                Vault</button>
            </form>

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
              <input type="text" placeholder=" Name" v-model="newKeep.name" class="form-input" required>
              <input type="text" placeholder=" Description" v-model="newKeep.description" class="form-input mt-3"
                id="desc" required>
              <input type="text" placeholder=" Image Url" v-model="newKeep.img" class="form-input mt-3" id="desc"
                required>
              </br>
              <button type="submit" class="btn form-btn mt-3">Create
                Keep</button>
            </form>
          </div>
        </div>
      </div>
    </div>

  </div>

  <!-- :class="$mq | mq({xs: '', sm: '', md: '', lg: ''})" -->
</template>

<script>
  import Vault from "@/components/Vault.vue";

  export default {
    name: "vaultsView",
    props: [],
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
      };
    },
    computed: {
      vaults() {
        return this.$store.state.myVaults;
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
      Vault
    }
  };
</script>