import { FormikValues, useFormik } from 'formik';

export const getFormikFieldProps = <T extends FormikValues>(
  formik: ReturnType<typeof useFormik<T>>,
  field: keyof T,
) => {
  return {
    value: formik.values[field],
    onChange: formik.handleChange,
    error: Boolean(formik.errors[field]),
    helperText: formik.errors[field],
    name: field,
  };
};

export const getFormikErrorProps = <T extends FormikValues>(
  formik: ReturnType<typeof useFormik<T>>,
  field: keyof T,
) => {
  return {
    error: Boolean(formik.errors[field]),
    helperText: formik.errors[field],
  };
};
