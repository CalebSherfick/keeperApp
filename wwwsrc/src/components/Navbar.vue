<template>
  <div class="navComponent">
    <nav
      :class="$mq | mq({xs: 'navbar sticky-top keeprBG row', sm: 'navbar sticky-top keeprBG row', md: 'navbar sticky-top navbar-expand-lg keeprBG row', lg: 'navbar sticky-top navbar-expand-lg keeprBG row'})">

      <a class="nav-text" @click="goDashboard" :class="$mq | mq({xs: '', sm: '', md: 'col-1', lg: 'col-1'})">Keepr</a>
      <a class="nav-text" @click="goDashboard"
        :class="$mq | mq({xs: '', sm: '', md: 'col-1 offset-5', lg: 'col-1 offset-5'})">Dashboard</a>
      <a class="nav-text" @click="goVaults" :class="$mq | mq({xs: '', sm: '', md: 'col-1', lg: 'col-1'})">My Vaults</a>
      <a class="nav-text" @click="" :class="$mq | mq({xs: '', sm: '', md: 'col-1', lg: 'col-1'})">My Keeps</a>
      <a class="nav-text" @click="logout" :class="$mq | mq({xs: '', sm: '', md: 'col-1', lg: 'col-1'})">Logout</a>

    </nav>
  </div>
</template>

<script>
  export default {
    name: "nav-component",
    props: [],
    data() {
      return {};
    },
    computed: {},
    methods: {
      logout() {
        this.$store.dispatch("logout");
      },
      goDashboard() {
        this.$router.push({ path: '/' })
      },
      goVaults() {
        this.$router.push({ path: '/vaults' })
      }
    },
    components: {}
  };
</script>

<style scoped>
  .curs {
    cursor: pointer;
  }

  .keeprBG {
    background-color: #687c68;
  }

  a:hover {
    cursor: pointer;
  }

  nav {
    max-width: 100%;
  }

  .nav-text {
    color: white !important;
  }

  .far,
  .fas {
    color: white;
  }
</style>