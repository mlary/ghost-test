/** @jsxImportSource @emotion/react */
import { css } from '@emotion/react';
import { Button, Card, TextField } from '@mui/material';

import { FormikProvider, useFormik } from 'formik';
import { useCallback } from 'react';
import { useAppDispatch, useAppSelector } from '~/app/store';
import { createRecruiter } from '~/slices/recruiter/recruiterSlice';
import LoadingState from '~/types/LoadingState';
import { getFormikFieldProps } from '~/utils/formikHelper';
import Spinner from '../Spinner/Spinner';
import { RecruiterPersonFormData, initialRecruiterPersonData, recruiterPersonSchema } from './RecruiterPersonModel';

const classes = {
  root: css({
    minWidth: 400,
    maxWidth: 800,
    width: '100%',
  }),
  card: css({
    display: 'flex',
    flexDirection: 'column',
    gap: 20,
    alignItems: 'center',
    padding: 16,
  }),
  formItem: css({ width: '100%' }),
  label: css({
    fontWeight: 600,
  }),
  actions: css({
    display: 'flex',
    justifyContent: 'flex-end',
    width: '100%',
  }),
  nextBtn: css({
    minWidth: 100,
  }),
  header: css({
    fontSize: '2rem',
  }),
};

const RecruiterPersonForm = () => {
  const dispatch = useAppDispatch();
  const { createRecruiterLoading } = useAppSelector((state) => state.recruiter);
  const { recruiterData } = useAppSelector((state) => state.rate);

  const handleSubmit = useCallback(
    (values: RecruiterPersonFormData) => {
      if (recruiterData) {
        dispatch(
          createRecruiter({
            ...values,
            ...recruiterData,
          }),
        );
      }
    },
    [recruiterData],
  );

  const formik = useFormik({
    initialValues: initialRecruiterPersonData,
    validationSchema: recruiterPersonSchema,
    onSubmit: handleSubmit,
  });
  return (
    <FormikProvider value={formik}>
      <div css={classes.root}>
        {createRecruiterLoading === LoadingState.pending && <Spinner size={32} />}
        <form id="recruiterPersonForm" onSubmit={formik.submitForm} autoComplete="off">
          <Card css={classes.card}>
            <h2 css={classes.header}>Enter recruiter</h2>
            <div css={classes.formItem}>
              <div css={classes.label}>Surname</div>
              <TextField fullWidth {...getFormikFieldProps(formik, 'surname')} />
            </div>
            <div css={classes.formItem}>
              <div css={classes.label}>First name</div>
              <TextField fullWidth {...getFormikFieldProps(formik, 'firstName')} />
            </div>
            <div css={classes.actions}>
              <Button onClick={formik.submitForm} color="primary" variant="contained" css={classes.nextBtn}>
                Next
              </Button>
            </div>
          </Card>
        </form>
      </div>
    </FormikProvider>
  );
};
export default RecruiterPersonForm;
