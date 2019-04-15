import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'

Vue.use(Vuex)

let baseUrl = location.host.includes('localhost') ? 'https://localhost:5001/' : '/'

let auth = Axios.create({
  baseURL: baseUrl + "account/",
  timeout: 3000,
  withCredentials: true
})

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    myVaults: []
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    setMyVaults(state, vaults) {
      state.myVaults = vaults
    }
  },
  actions: {
    register({ commit, dispatch }, newUser) {
      auth.post('register', newUser)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('[registration failed] :', e)
        })
    },
    authenticate({ commit, dispatch }) {
      auth.get('authenticate')
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('not authenticated')
        })
    },
    login({ commit, dispatch }, creds) {
      auth.post('login', creds)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('Login Failed')
        })
    },

    //#region  --VAULTS--

    //CREATE VAULTS
    createVault({ commit, dispatch }, payload) {
      debugger
      api.post('vaults', payload)
        .then(res => {
          commit('setMyVaults', res.data)
          console.log(res.data)
        })
    },

    //GET VAULTS
    getVaults({ commit, dispatch }) {
      debugger
      api.get('vaults')
        .then(res => {
          commit('setMyVaults', res.data)
        })
    }

    //#endregion










  }
})
