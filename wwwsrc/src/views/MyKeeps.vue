<template>
  <div class="myKeeps container-fluid">
    <h1>My Keeps</h1>

    <section class="row vaults">
      <div class="col-12">
        <div class="row">
          <my-keep v-for="keep in keeps" :keep="keep"></my-keep>
        </div>
      </div>
    </section>

  </div>


  <!-- :class="$mq | mq({xs: '', sm: '', md: '', lg: ''})" -->


</template>

<script>
  import MyKeep from "@/components/MyKeep.vue"

  export default {
    name: "myKeeps",
    mounted() {
      //blocks users not logged in
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "login" });
      }
      //Get vaultkeeps
      this.$store.dispatch('getMyKeeps');
    },
    data() {
      return {
      }
    },
    computed: {
      keeps() {
        return this.$store.state.keeps
      }
    },
    methods: {

    },
    components: {
      MyKeep
    }

  };
</script>