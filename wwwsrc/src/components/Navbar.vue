<template>
  <div class="navComponent">



    <mq-layout mq="md">
      <nav
        :class="$mq | mq({xs: 'navbar keeprBG row', sm: 'navbar keeprBG row', md: 'navbar navbar-expand-lg keeprBG row', lg: 'navbar navbar-expand-lg keeprBG row'})">

        <a class="nav-text" @click="clearKeeps(); goDashboard()"
          :class="$mq | mq({xs: 'col-12', sm: 'col-12', md: 'col-1 offset-2', lg: 'col-1 offset-2'})">Keepr</a>
        <div
          :class="$mq | mq({xs: 'col-12 d-flex justify-content-around', sm: 'col-12 d-flex justify-content-around', md: 'col-2 d-flex justify-content-start', lg: 'col-2 d-flex justify-content-start'})">
          <button type="button" class="btn create-btn" data-toggle="modal" data-target="#createVaultMod">
            <i class="fas fa-plus"></i> New Vault
          </button>

          <button type="button" class="btn create-btn ml-1" data-toggle="modal" data-target="#createKeepMod">
            <i class="fas fa-plus"></i> New Keep
          </button>

        </div>


        <a class="nav-text" @click="clearKeeps(); goVaults()"
          :class="$mq | mq({xs: 'col-12', sm: 'col-12', md: 'col-1', lg: 'offset-3 col-1'})">My
          Vaults</a>
        <a class="nav-text" @click="clearKeeps(); goMyKeeps()"
          :class="$mq | mq({xs: 'col-12', sm: 'col-12', md: 'col-1', lg: 'col-1'})">My Keeps</a>
        <a class="nav-text" @click="logout"
          :class="$mq | mq({xs: 'col-12', sm: 'col-12', md: 'col-1', lg: 'col-1'})">Logout</a>
      </nav>
    </mq-layout>

    <mq-layout mq="lg">
      <nav
        :class="$mq | mq({xs: 'navbar keeprBG row', sm: 'navbar keeprBG row', md: 'navbar navbar-expand-lg keeprBG row', lg: 'navbar navbar-expand-lg keeprBG row'})">

        <a class="nav-text" @click="clearKeeps(); goDashboard()"
          :class="$mq | mq({xs: 'col-12', sm: 'col-12', md: 'col-1 offset-2', lg: 'col-1 offset-2'})">Keepr</a>
        <div
          :class="$mq | mq({xs: 'col-12 d-flex justify-content-around', sm: 'col-12 d-flex justify-content-around', md: 'col-2 d-flex justify-content-start', lg: 'col-2 d-flex justify-content-start'})">
          <button type="button" class="btn create-btn" data-toggle="modal" data-target="#createVaultMod">
            <i class="fas fa-plus"></i> New Vault
          </button>

          <button type="button" class="btn create-btn ml-1" data-toggle="modal" data-target="#createKeepMod">
            <i class="fas fa-plus"></i> New Keep
          </button>

        </div>


        <a class="nav-text" @click="clearKeeps(); goVaults()"
          :class="$mq | mq({xs: 'col-12', sm: 'col-12', md: 'col-1', lg: 'offset-3 col-1'})">My
          Vaults</a>
        <a class="nav-text" @click="clearKeeps(); goMyKeeps()"
          :class="$mq | mq({xs: 'col-12', sm: 'col-12', md: 'col-1', lg: 'col-1'})">My Keeps</a>
        <a class="nav-text" @click="logout"
          :class="$mq | mq({xs: 'col-12', sm: 'col-12', md: 'col-1', lg: 'col-1'})">Logout</a>
      </nav>
    </mq-layout>


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
        this.$store.dispatch("setActiveVault", {})
      },
      clearKeeps() {
        this.$store.dispatch("clearKeeps", [])
      },
      goDashboard() {
        this.$router.push({ path: '/' })
      },
      goVaults() {
        this.$router.push({ path: '/vaults' })
      },
      goMyKeeps() {
        this.$router.push({ path: '/mykeeps' })
      }
    },
    components: {}
  };
</script>

<style scoped>
  .curs {
    cursor: pointer;
  }

  .navComponent {
    background-color: #34373c;
  }

  .create-btn {
    background-color: #1bb76e;
    display: inline-block;
    padding: 5px 0 2px 12px;
    line-height: 150%;
    font-size: 14px;
    font-weight: 500;
    color: #f2f2f2;
    width: 105px;
    text-align: start;
  }

  a:hover {
    cursor: pointer;
  }

  nav {
    width: 100%;
    font-size: 15px;
    position: relative;
    top: 0;
  }

  .nav-text {
    color: #f2f2f2 !important;
  }

  .far,
  .fas {
    color: #f2f2f2;
  }





  .create-btn {
    transition: all 0.1s linear;
  }

  .create-btn:hover {
    box-shadow: 1px 1px 2px black;
    background-color: #60a7f4 !important;
    transform: scale(1.02);
    cursor: pointer;
  }

  .create-btn:active {
    box-shadow: none;
    background-color: #007bff !important;
    transform: scale(1.01);
  }
</style>