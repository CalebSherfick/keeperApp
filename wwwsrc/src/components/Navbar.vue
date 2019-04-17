<template>
  <div class="navComponent">
    <nav
      :class="$mq | mq({xs: 'navbar sticky-top keeprBG row', sm: 'navbar sticky-top keeprBG row', md: 'navbar sticky-top navbar-expand-lg keeprBG row', lg: 'navbar sticky-top navbar-expand-lg keeprBG row'})">

      <a class="nav-text" @click="" :class="$mq | mq({xs: '', sm: '', md: 'col-1', lg: 'col-1'})">Keepr</a>
      <a class="nav-text" @click=""
        :class="$mq | mq({xs: '', sm: '', md: 'col-1 offset-5', lg: 'col-1 offset-5'})">Dashboard</a>
      <a class="nav-text" @click="" :class="$mq | mq({xs: '', sm: '', md: 'col-1', lg: 'col-1'})">My Vaults</a>
      <a class="nav-text" @click="" :class="$mq | mq({xs: '', sm: '', md: 'col-1', lg: 'col-1'})">My Keeps</a>
      <a class="nav-text" @click="logout" :class="$mq | mq({xs: '', sm: '', md: 'col-1', lg: 'col-1'})">Logout</a>











      <!-- <mq-layout mq="xs">
        <i class="far fa-plus-square fa-2x" @click="makePost()"></i>
      </mq-layout>
      <mq-layout mq="sm">
        <i class="far fa-plus-square fa-2x" @click="makePost()"></i>
      </mq-layout>
      <mq-layout mq="md">
        <p>Keepr</p>
      </mq-layout>
      <mq-layout mq="lg">
        <p>Keepr</p>
      </mq-layout>


      <mq-layout mq="xs">
        <i class="fas fa-sign-out-alt fa-2x" @click="logout()"></i>
      </mq-layout>
      <mq-layout mq="sm">
        <i class="fas fa-sign-out-alt fa-2x" @click="logout()"></i>
      </mq-layout>

      <div class="collapse navbar-collapse">
        <a class="nav-item nav-link curs" @click="allPosts();">
          Dashboard
        </a>
        <a class="nav-item nav-link curs" @click="goPosts();">
          My Vaults
        </a>
        <a class="nav-item nav-link curs" @click="myProfile();">My Keeps</a>
        <a class="nav-item nav-link curs" @click="makePost();">Make
          Post</a>
        <a class="nav-item nav-link curs" @click="logout(); activeClass = null">Logout</a>
      </div> -->

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