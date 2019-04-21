<template>
  <div class="dashboard container-fluid">
    <h1 class="view-title">Discover Keeps</h1>

    <section class="row vaults">
      <div class="col-12">
        <keep></keep>
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
  import Vault from "@/components/Vault.vue"
  import Keep from "@/components/Keep.vue"

  export default {
    name: "dashboard",
    mounted() {
      //blocks users not logged in
      // if (!this.$store.state.user.id) {
      //   this.$router.push({ name: "login" });
      // }
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

<style>
  .view-title {
    color: #f2f2f2;
  }

  .modal-header {
    background-color: #2c2f34;
    border-radius: 0px;
  }

  .modal-body,
  .modal-footer {
    background-color: #45484f;
    border-radius: 0px;
  }

  .modal-title,
  .modal-body,
  .modal-footer {
    color: #f2f2f2;
  }

  .close {
    color: #f2f2f2;
  }

  .close:hover {
    color: white;
  }

  .form-input {
    width: 100%;
    padding: 8px;
    font-size: 15px;
    border: 1px solid rgba(255, 255, 255, .38);
    border-radius: 5px;
    box-sizing: border-box;
    background-color: #45484f;
    box-shadow: inset 0 2px 6px 0 rgba(0, 0, 0, .26);
    color: #696969;
    text-align: center;
    outline: 0;
  }

  .form-btn {
    display: inline-block;
    color: #333;
    padding: 4px 15px;
    margin: 0 5px;
    border-radius: 5px;
    background-image: linear-gradient(to bottom, #e0e0e0, #B6BECB);
    box-shadow: 0 2px 4px 0 rgba(0, 0, 0, .5);
  }

  .form-btn:hover {
    transform: scale(1.02);
    cursor: pointer;
  }

  .form-btn:active {
    box-shadow: none;
    transform: scale(1.01);
  }
</style>