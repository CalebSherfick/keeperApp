<template>
  <div id="app">
    <navbar />
    <router-view />
  </div>
</template>

<script>
  import Navbar from '@/components/Navbar.vue'
  export default {
    components: {
      Navbar
    }
  }
</script>

<style>
  #app {
    /* font-family: "Avenir", Helvetica, Arial, sans-serif; */

    /* font-family: 'Montserrat', sans-serif; */
    /* font-family: 'Nunito', sans-serif; */
    /* font-family: 'Nanum Gothic', sans-serif; */
    /* font-family: 'BenchNine', sans-serif; */
    font-family: 'Montserrat Alternates', sans-serif;
    /* font-family: 'Julius Sans One', sans-serif; */

    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
  }

  body {
    background-color: #141518;
  }

  #nav {
    padding: 30px;
  }

  #nav a {
    font-weight: bold;
    color: #2c3e50;
  }

  #nav a.router-link-exact-active {
    color: #42b983;
  }
</style>