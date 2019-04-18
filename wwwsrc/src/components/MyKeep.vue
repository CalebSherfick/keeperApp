<template>
  <div :class="$mq | mq({xs: 'col-12', sm: 'col-12', md: '', lg: 'col-3'})">
    <img :src="keep.img" :class="$mq | mq({xs: 'w-100', sm: 'w-100', md: 'w-100', lg: 'w-100'})">
    <p>{{keep.name}}</p>
    <p>{{keep.description}}</p>
    <button class="btn btn-danger px-4 mb-2" @click="deleteKeep(keep.id)">Delete</button>
  </div>
</template>

<script scoped>
  export default {
    name: "myKeep",
    props: ["keep"],
    data() {
      return {};
    },
    computed: {
      keeps() {
        return this.$store.state.mykeeps
      }
    },
    methods: {
      deleteKeep(keepId) {
        this.$store.dispatch("deleteKeep", keepId);
      }
    },
    components: {
    }
  };
</script>