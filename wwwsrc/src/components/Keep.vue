<template>
  <!-- <div :class="$mq | mq({xs: 'col-12', sm: 'col-12', md: '', lg: 'col-3'})"> -->
  <!-- <waterfall-slot move-class="item-move1" v-if="keep.width" :width="keep.width" :height="keep.height" class="anim p-1"
    :order="keep.id" :key="keep.id"> -->



  <waterfall :line-gap="250" align="center" :watch="this.keeps" style="max-height:100%;">
    <!-- each component is wrapped by a waterfall slot -->
    <waterfall-slot v-for="(keep, index) in keeps" move-class="item-move1" v-if="keep.width" :width="keep.width"
      :height="keep.height" class="anim p-1" :order="keep.id" :key="keep.id">

      <img :src="keep.img" :class="$mq | mq({xs: 'w-100', sm: 'w-100', md: 'w-100', lg: 'w-100'})">
      <!-- <p>{{keep.name}}</p>
      <p>{{keep.description}}</p> -->

      <!-- Button trigger modal -->
      <!-- <button @click="increaseViewCount(keep.id)" type="button" class="btn btn-success" data-toggle="modal"
        :data-target="'#keepModal' + keep.id">
        View Keep
      </button> -->

      <!-- Modal -->
      <!-- <div class="modal" :id="'keepModal' + keep.id" tabindex="-1" role="dialog" aria-labelledby="keepModalLabel"
        aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h5 class="modal-title" id="keepModalLabel">{{keep.name}}</h5>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              <img class="card-img-top" :src="keep.img">
            </div>
            <div class="modal-footer"> -->
      <!-- DropUp Button -->
      <!-- <div class="btn-group dropup">
                <button type="button" class="btn btn-secondary dropdown-toggle" data-toggle="dropdown"
                  aria-haspopup="true" aria-expanded="false">
                  Add to Vault
                </button>
                <div class="dropdown-menu">
                  <a class="dropdown-item" @click="createVaultKeep(vault.id, keep.id)"
                    v-for="vault in vaults">{{vault.name}}</a>
                </div>
              </div> -->

      <!-- <button type="button" class="btn btn-secondary" data-dismiss="modal">Add to Vault</button> -->
      <!-- </div>
          </div>
        </div>
      </div> -->

    </waterfall-slot>
  </waterfall>

  <!-- <button class="btn btn-danger px-4 mb-2" @click="deleteKeep(keep.id)">Delete</button> -->
  <!-- </waterfall-slot> -->
  <!-- </div> -->
</template>

<script>
  import Waterfall from 'vue-waterfall/lib/waterfall';
  import WaterfallSlot from 'vue-waterfall/lib/waterfall-slot';
  import Keep from "@/components/Keep.vue"
  export default {
    name: "keep",
    props: ["keep"],
    data() {
      return {
        waterfallOrder: this.$store.state.keeps.map(keep => keep.id)
      };
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
      deleteKeep(keepId) {
        this.$store.dispatch("deleteKeep", keepId);
      },
      createVaultKeep(vaultId, keepId) {
        this.$store.dispatch("createVaultKeep", {
          VaultId: vaultId,
          KeepId: keepId
        })
      },
      increaseViewCount(keepId) {
        this.$store.dispatch("increaseViewCount", keepId)
      }
    },
    components: {
      Keep,
      Waterfall,
      WaterfallSlot
    }
  };
</script>

<style scoped>
  #keepButtons {
    transition: all 0.1s linear;
  }

  #keepButtons:hover {
    box-shadow: 1px 1px 2px black;
    background-color: #60a7f4 !important;
    transform: scale(1.02);
    cursor: pointer;
  }

  .sizing {
    max-width: 100%;
  }

  .item-move {
    transition: all 2s cubic-bezier(.55, 0, .1, 1) !important;
  }

  .item-move1 {
    transition: ease-in 2s all
  }

  #keepButtons:active {
    box-shadow: none;
    background-color: #007bff !important;
    transform: scale(1.01);
  }

  .bg-color {
    background-color: black;
  }

  .anim {
    /* box-shadow: -5px 5px 5px 0px rgba(152, 84, 187, 1) !important; */
    transition: .5s cubic-bezier(.55, 0, .1, 1);
  }

  .vue-waterfall {
    overflow: visible !important
  }

  .keepClass {
    position: relative;
    width: 100%;
  }

  .keepImage {
    display: block;
    width: 100%;
    height: auto;
  }

  .keepImage:hover {
    display: block;
    width: 100%;
    height: auto;
    cursor: pointer;
  }

  .text {
    color: white;
    font-size: 15px;
    position: absolute;
    top: 40%;
    left: 50%;
    transform: translate(-50%, -50%);
    text-align: center;
  }

  .text2 {
    color: white;
    font-size: 15px;
    position: absolute;
    top: 60%;
    left: 50%;
    transform: translate(-50%, -50%);
    text-align: center;
  }

  .overlay {
    position: absolute;
    bottom: 0;
    left: 0;
    right: 0;
    background-color: #9854bb;
    overflow: hidden;
    width: 100%;
    height: 0;
    transition: .5s ease;
  }

  .overlay2 {
    position: absolute;
    top: 0;
    left: 0;
    right: 0;
    background-color: rgba(128, 128, 128, 0.441);
    overflow: hidden;
    width: 100%;
    height: 0;
    transition: .5s ease;
  }

  .keepClass:hover .overlay2 {
    height: 65%;
    cursor: pointer;
  }

  .keepClass:hover .overlay {
    height: 35%;
    cursor: pointer;
  }
</style>