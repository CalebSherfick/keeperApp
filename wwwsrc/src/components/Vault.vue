<template>
  <waterfall :line-gap="350" align="center" :watch="this.vaults" style="max-height:100%" interval=100>
    <waterfall-slot v-for="(vault, index) in vaults" move-class="item-move" v-if="vault.width" :width="vault.width"
      :height="vault.height" class="p-1" :order="vault.id" :key="vault.id">
      <div class="whole-vault">
        <img class="vaultImg" :src="vault.imgUrl">
        <div class="overlay-top" @click="vaultKeeps(vault.id); setActiveVault(vault)">
          <h1 class="vault-name">{{vault.name}}</h1>
          <p class=" view-details">{{vault.description}}</p>
        </div>
        <div class="overlay-bottom" data-toggle="modal" :index="vault.id" :data-target="'#vaultModal' + vault.id">
          <div class="row">
            <div class="col-12 d-flex align-items-end h-100 justify-content-center">
              <p class="text-white" style="font-weight:750;">Delete Vault</p>
            </div>
          </div>
        </div>
      </div>


      <!-- Modal -->
      <div class="modal" :id="'vaultModal' + vault.id" tabindex="-1" role="dialog" aria-labelledby="vaultModalLabel"
        aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
          <div class="modal-content">
            <div class="modal-header text-center d-flex justify-content-center">
              <h5 class="modal-title" id="vaultModalLabel">Delete {{vault.name}}?</h5>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-footer d-flex justify-content-center">
              <p>Deleting will remove all keeps from {{vault.name}}</p>
            </div>
            <div class="btn-group dropup">
              <button class="btn delete-btn" @click="deleteVault(vault.id)" data-dismiss="modal">Delete Vault</button>
            </div>
          </div>
        </div>
      </div>


    </waterfall-slot>
  </waterfall>
</template>



<script>
  import Waterfall from 'vue-waterfall/lib/waterfall';
  import WaterfallSlot from 'vue-waterfall/lib/waterfall-slot';
  export default {
    name: "vault",
    props: ["vault"],
    data() {
      return {};
    },
    computed: {
      vaults() {
        return this.$store.state.myVaults;
      }
    },
    methods: {
      deleteVault(vaultId) {
        this.$store.dispatch("deleteVault", vaultId);
      },
      vaultKeeps(id) {
        this.$router.push({
          path: "/vaults/" + id + "/keeps"
        })
      },
      setActiveVault(vault) {
        this.$store.dispatch("setActiveVault", vault);
      }

    },
    components: {
      Waterfall,
      WaterfallSlot
    }
  };
</script>

<style scoped>
  /* #keepButtons {
    transition: all 0.1s linear;
  }

  #keepButtons:hover {
    box-shadow: 1px 1px 2px black;
    background-color: #60a7f4 !important;
    transform: scale(1.02);
    cursor: pointer;
  } */

  .item-move {
    /* transition: all 2s cubic-bezier(.55, 0, .1, 1) !important; */
    transition: all .5s cubic-bezier(.55, 0, .1, 1) !important;
    -webkit-transition: all .5s cubic-bezier(.55, 0, .1, 1) !important;
  }

  /* #keepButtons:active {
    box-shadow: none;
    background-color: #007bff !important;
    transform: scale(1.01);
  } */

  .bg-color {
    background-color: black;
  }

  .vue-waterfall {
    overflow: visible !important
  }

  .whole-vault {
    position: relative;
    width: 100%;
  }

  .vaultImg {
    display: block;
    width: 100%;
    height: auto;
  }

  .vaultImg:hover {
    cursor: pointer;
  }

  .vault-name {
    color: white;
    text-align: center;
    left: 50%;
  }

  .view-details {
    color: white;
    position: absolute;
    text-align: center;
    font-size: 15px;
    transform: translate(-50%, -50%);
    top: 40%;
    left: 50%;
  }

  .overlay-bottom {
    position: absolute;
    bottom: 0;
    left: 0;
    right: 0;
    background-color: rgb(202, 134, 134);
    overflow: hidden;
    width: 100%;
    height: 10%;
    transition: .5s ease;
  }

  .overlay-top {
    position: absolute;
    top: 0;
    left: 0;
    right: 0;
    background-color: rgba(51, 51, 51, 0.336);
    overflow: hidden;
    width: 100%;
    height: 90%;
    transition: .5s ease;
  }

  .whole-vault:hover .overlay-bottom {
    cursor: pointer;
  }

  .whole-vault:hover .overlay-top {
    cursor: pointer;
  }

  .delete-btn {
    background-color: rgb(202, 134, 134);
    border-radius: 0px;
  }
</style>