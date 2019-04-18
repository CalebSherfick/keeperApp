<template>
  <div class="vaultsView container-fluid">
    <h1>My Vaults</h1>
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
    return {};
  },
  computed: {
    vaults() {
      return this.$store.state.myVaults;
    }
  },
  methods: {},
  components: {
    Vault
  }
};
</script>