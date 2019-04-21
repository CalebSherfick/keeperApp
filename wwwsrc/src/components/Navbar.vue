<template>
  <div class="navComponent">

    <mq-layout mq="xs">
      <nav class="navbar m-0 keeprBG row justify-content-start">
        <div class="col-1 d-flex justify-content-center">
          <radial-menu style="background-color: #f2f2f2" :itemSize="50" :size=50 :radius="90" :rotate=225
            :angle-restriction="45">
            <radial-menu-item v-for="(item, index) in items" :key="index" style="background-color: #f2f2f2"
              @click="() => handleClick(item)">
              <span>{{item}}</span>
            </radial-menu-item>
          </radial-menu>
        </div>
        <div class="offset-10 col-1 d-flex justify-content-center">
          <i class="fas fa-bars fa-3x" data-toggle="collapse" data-target="#nav-bar-collapse"></i>
        </div>

        <!-- Collect the nav links, forms, and other content for toggling -->
        <div class="navbar-collapse" id="nav-bar-collapse">
          <ul class="nav navbar-nav">
            <a class="nav-text-mobile col-12" @click="clearKeeps(); goVaults()">My
              Vaults</a>
            <a class="nav-text-mobile col-12" @click="clearKeeps(); goMyKeeps()">My Keeps</a>
            <a class="nav-text-mobile col-12" @click="logout">Logout</a>
          </ul>
        </div>





      </nav>
    </mq-layout>

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
  import { RadialMenu, RadialMenuItem } from 'vue-radial-menu'
  export default {
    name: "nav-component",
    props: [],
    data() {
      return {
        items: ['Keep', 'Vault']
      };
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
      },
      handleClick(item) {
        if (item == "Keep") {
          $('#createKeepMod').modal('show')
        } else if (item == "Vault") {
          $('#createVaultMod').modal('show')
        }
      }
    },
    components: {
      RadialMenu,
      RadialMenuItem
    }
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