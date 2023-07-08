/** @jsxImportSource @emotion/react */
import { css } from '@emotion/react';
import { Button, Card, TextField } from '@mui/material';
import { FormikProvider, useFormik } from 'formik';
import { useCallback } from 'react';
import { AuthenticateCommand } from '~/app/ApiClient';
import { useAppDispatch } from '~/app/store';
import { authenticate } from '~/slices/users/usersSlice';
import { getFormikFieldProps } from '~/utils/formikHelper';
import { initialLoginFormData, loginFormSchema } from './LoginFormSchema';

const classes = {
  root: css({
    alignItems: 'center',
    display: 'flex',
    justifyContent: 'center',
    height: '100%',
  }),
  card: css({
    width: 400,
    height: 400,
    display: 'flex',
    flexDirection: 'column',
    justifyContent: 'center',
    alignItems: 'center',
    gap: 30,
    marginTop: 80,
  }),
  title: css({
    fontWeight: 600,
    fontSize: 22,
  }),
  label: css({}),
  input: css({}),
  loginBtn: css({}),
};

const SignIn = () => {
  const dispatch = useAppDispatch();
  const handleSubmit = useCallback((values: AuthenticateCommand) => {
    dispatch(authenticate(values));
  }, []);
  const formik = useFormik({
    initialValues: initialLoginFormData,
    validationSchema: loginFormSchema,
    onSubmit: handleSubmit,
  });
  return (
    <div css={classes.root}>
      <FormikProvider value={formik}>
        <form onSubmit={formik.submitForm} autoComplete="off">
          <Card css={classes.card}>
            <div css={classes.title}>Login</div>
            <div>
              <TextField {...getFormikFieldProps(formik, 'email')} type="email" fullWidth label="Email" />
            </div>
            <div>
              <TextField {...getFormikFieldProps(formik, 'password')} type="password" fullWidth label="Password" />
            </div>
            <div>
              <Button color="primary" onClick={formik.submitForm} variant="contained">
                Sign In
              </Button>
            </div>
          </Card>
        </form>
      </FormikProvider>
    </div>
  );
};
export default SignIn;
