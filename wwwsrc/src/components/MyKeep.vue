<template>
  <waterfall :line-gap="350" align="center" :watch="this.keeps" style="max-height:100%" interval=100>
    <waterfall-slot v-for="(keep, index) in keeps" move-class="item-move" v-if="keep.width" :width="keep.width"
      :height="keep.height" class="p-1" :order="keep.id" :key="keep.id">
      <div class="whole-keep">
        <img data-toggle="modal" :index="keep.id" :data-target="'#keepModal' + keep.id" class="keepImg" :src="keep.img">
        <div
          :class="$mq | mq({xs: 'overlay-mobile-top', sm: 'overlay-mobile-top', md: 'overlay-top', lg: 'overlay-top'})"
          data-toggle="modal" :index="keep.id" :data-target="'#keepModal' + keep.id">
          <p class="view-details">VIEW DETAILS</p>
        </div>
        <div
          :class="$mq | mq({xs: 'overlay-mobile-bottom', sm: 'overlay-mobile-bottom', md: 'overlay-bottom', lg: 'overlay-bottom'})"
          data-toggle="modal" :index="keep.id" :data-target="'#keepModal' + keep.id">
          <div class="row">
            <div class="col-12 d-flex align-items-end h-100 justify-content-center">
              <p class="text-white" style="font-weight:750;"> {{keep.name}}</p>
            </div>
          </div>
        </div>
      </div>

      <!-- Modal -->
      <div class="modal" :id="'keepModal' + keep.id" tabindex="-1" role="dialog" aria-labelledby="keepModalLabel"
        aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
          <div class="modal-content">
            <div class="modal-header text-center d-flex justify-content-center">
              <h5 class="modal-title" id="keepModalLabel">{{keep.name}}</h5>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              <img class="card-img-top" :src="keep.img">
            </div>
            <div class="modal-footer d-flex justify-content-center">
              <p>{{keep.description}}</p>
            </div>
            <div class="btn-group dropup">
              <button class="btn delete-btn" @click="deleteKeep(keep.id)" data-dismiss="modal">Delete Keep</button>
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
  import Keep from "@/components/Keep.vue"
  export default {
    name: "myKeep",
    props: ["keep"],
    data() {
      return {
        waterfallOrder: this.$store.state.keeps.map(keep => keep.id)
      };
    },
    computed: {
      keeps() {
        return this.$store.state.keeps
      }
    },
    methods: {
      deleteKeep(keepId) {
        this.$store.dispatch("deleteKeep", keepId);
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

  .whole-keep {
    position: relative;
    width: 100%;
  }

  .keepImg {
    display: block;
    width: 100%;
    height: auto;
  }

  .keepImg:hover {
    cursor: pointer;
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
    background-color: #687c68;
    overflow: hidden;
    width: 100%;
    height: 0;
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
    height: 0;
    transition: .5s ease;
  }

  .whole-keep:hover .overlay-bottom {
    height: 20%;
    cursor: pointer;
  }

  .whole-keep:hover .overlay-top {
    height: 80%;
    cursor: pointer;
  }

  .overlay-mobile-bottom {
    position: absolute;
    bottom: 0;
    left: 0;
    right: 0;
    background-color: #687c68;
    overflow: hidden;
    width: 100%;
    height: 20%;
    transition: .5s ease;
  }

  .overlay-mobile-top {
    position: absolute;
    top: 0;
    left: 0;
    right: 0;
    background-color: rgba(51, 51, 51, 0.336);
    overflow: hidden;
    width: 100%;
    height: 80%;
    transition: .5s ease;
  }

  .whole-vault:hover .overlay-mobile-bottom {
    cursor: pointer;
  }

  .whole-vault:hover .overlay-mobile-top {
    cursor: pointer;
  }

  .delete-btn {
    background-color: rgb(202, 134, 134);
    border-radius: 0px;
  }
</style>