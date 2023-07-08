import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import { AuthenticateCommand, CreateUserCommand, IUsersClient, UpdateUserCommand, UsersClient } from '~/app/ApiClient';
import LoadingState from '~/types/LoadingState';
import { initialUsersState } from './usersState';

const TOKEN = 'TOKEN';
const userClient: IUsersClient = new UsersClient(process.env.REACT_APP_API_URL);

export const authenticate = createAsyncThunk('users/authenticate', async (command: AuthenticateCommand) => {
  const response = await userClient.authenticate(command);
  localStorage.setItem(TOKEN, response);
  return response;
});

export const getCurrentUser = createAsyncThunk('users/getCurrentUser', async () => {
  const response = await userClient.getCurrent();
  return response;
});

export const getUsers = createAsyncThunk('users/getUsers', async () => {
  const response = await userClient.getAll();
  return response;
});

export const createUser = createAsyncThunk('users/createUser', async (command: CreateUserCommand) => {
  const response = await userClient.create(command);
  return response;
});

export const updateUser = createAsyncThunk('users/updateUser', async (command: UpdateUserCommand) => {
  const response = await userClient.update(command);
  return response;
});

export const changeStatus = createAsyncThunk(
  'users/changeStatus',
  async ({ id, blocked }: { id: number; blocked: boolean }) => {
    const response = await userClient.changeStatus(id, blocked);
    return response;
  },
);

export const deleteUser = createAsyncThunk('users/deleteUser', async (id: number) => {
  const response = await userClient.delete(id);
  return response;
});

createSlice({
  name: 'users',
  initialState: initialUsersState,
  reducers: {
    resetCurrentUser: (state) => {
      state.current = null;
    },
    logout: (state) => {
      state.authToken = null;
      state.current = null;
      localStorage.removeItem(TOKEN);
    },
    resetUsers: (state) => {
      state.users = [];
    },
  },
  extraReducers: (builder) => {
    // Authenticate
    builder.addCase(authenticate.pending, (state) => {
      state.authLoading = LoadingState.pending;
      state.current = null;
      state.authToken = null;
    });
    builder.addCase(authenticate.fulfilled, (state, { payload }) => {
      state.authLoading = LoadingState.succeed;
      state.authToken = payload;
    });
    builder.addCase(authenticate.rejected, (state) => {
      state.authLoading = LoadingState.failed;
    });
    //getCurrentUser
    builder.addCase(getCurrentUser.pending, (state) => {
      state.loading = LoadingState.pending;
      state.current = null;
    });
    builder.addCase(getCurrentUser.fulfilled, (state, { payload }) => {
      state.loading = LoadingState.succeed;
      state.current = payload;
    });
    builder.addCase(getCurrentUser.rejected, (state) => {
      state.loading = LoadingState.failed;
    });
    //getUsers
    builder.addCase(getUsers.pending, (state) => {
      state.loading = LoadingState.pending;
    });
    builder.addCase(getUsers.fulfilled, (state, { payload }) => {
      state.loading = LoadingState.succeed;
      state.users = payload;
    });
    builder.addCase(getUsers.rejected, (state) => {
      state.loading = LoadingState.failed;
    });
    //create
    builder.addCase(createUser.pending, (state) => {
      state.userLoading = LoadingState.pending;
    });
    builder.addCase(createUser.fulfilled, (state, { payload }) => {
      state.userLoading = LoadingState.succeed;
      state.users = [...state.users, payload];
    });
    builder.addCase(createUser.rejected, (state) => {
      state.userLoading = LoadingState.failed;
    });

    //update
    builder.addCase(updateUser.pending, (state) => {
      state.userLoading = LoadingState.pending;
    });
    builder.addCase(createUser.fulfilled, (state, { payload }) => {
      state.userLoading = LoadingState.succeed;
      state.users = state.users.map((row) => (row.id === payload.id ? payload : row));
    });
    builder.addCase(createUser.rejected, (state) => {
      state.userLoading = LoadingState.failed;
    });

    //delete
    builder.addCase(deleteUser.pending, (state) => {
      state.userLoading = LoadingState.pending;
    });
    builder.addCase(deleteUser.fulfilled, (state, { meta: { arg } }) => {
      state.userLoading = LoadingState.succeed;
      state.users = state.users.filter((row) => row.id !== arg);
    });
    builder.addCase(deleteUser.rejected, (state) => {
      state.userLoading = LoadingState.failed;
    });

    //change status
    builder.addCase(changeStatus.pending, (state) => {
      state.userLoading = LoadingState.pending;
    });
    builder.addCase(changeStatus.fulfilled, (state, { meta: { arg } }) => {
      state.userLoading = LoadingState.succeed;
      state.users = state.users.map((row) => (row.id === arg.id ? { ...row, blocked: arg.blocked } : row));
    });
    builder.addCase(changeStatus.rejected, (state) => {
      state.userLoading = LoadingState.failed;
    });
  },
});
