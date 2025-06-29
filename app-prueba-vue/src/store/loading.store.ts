import { MutationTree, Module } from 'vuex';

interface LoadingState {
  refCount: number;
  isLoading: boolean;
}

const state: LoadingState = {
  refCount: 0,
  isLoading: false,
};

const mutations: MutationTree<LoadingState> = {
  loading(state, isLoading: boolean) {
    if (isLoading) {
      state.refCount++;
      state.isLoading = true;
    } else if (state.refCount > 0) {
      state.refCount--;
      state.isLoading = state.refCount > 0;
    }
  },
};

export const loading: Module<LoadingState, any> = {
  state,
  mutations,
};
