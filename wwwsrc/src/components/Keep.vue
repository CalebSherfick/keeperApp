<template>
  <div :class="$mq | mq({xs: 'col-12', sm: 'col-12', md: '', lg: 'col-3'})">
    <img :src="keep.img" :class="$mq | mq({xs: 'w-100', sm: 'w-100', md: 'w-100', lg: 'w-100'})">
    <p>{{keep.name}}</p>
    <p>{{keep.description}}</p>
    <button class="btn btn-danger px-4 mb-2" @click="deleteKeep(keep.id)">Delete</button>

    <!-- Button trigger modal -->
    <button type="button" class="btn btn-success" data-toggle="modal" :data-target="'#keepModal' + keep.id">
      View Keep
    </button>

    <!-- Modal -->
    <div class="modal" :id="'keepModal' + keep.id" tabindex="-1" role="dialog" aria-labelledby="keepModalLabel"
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
          <div class="modal-footer">
            <!-- DropUp Button -->
            <div class="btn-group dropup">
              <button type="button" class="btn btn-secondary dropdown-toggle" data-toggle="dropdown"
                aria-haspopup="true" aria-expanded="false">
                Add to Vault
              </button>
              <div class="dropdown-menu">
                <a class="dropdown-item" @click="createVaultKeep(vault.id, keep.id)"
                  v-for="vault in vaults">{{vault.name}}</a>
              </div>
            </div>

            <!-- <button type="button" class="btn btn-secondary" data-dismiss="modal">Add to Vault</button> -->
          </div>
        </div>
      </div>
    </div>



  </div>
</template>

<script>
  export default {
    name: "keep",
    props: ["keep"],
    data() {
      return {};
    },
    computed: {
      vaults() {
        return this.$store.state.myVaults
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
      }
    },
    components: {
    }
  };
</script>