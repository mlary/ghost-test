/** @jsxImportSource @emotion/react */
import { css } from '@emotion/react';
import CircularProgress, { CircularProgressProps } from '@mui/material/CircularProgress';
import { FC } from 'react';

const classes = {
  root: css({
    position: 'absolute',
    top: 0,
    bottom: 0,
    left: 0,
    right: 0,
    margin: "auto",
  }),
};
const Spinner: FC<CircularProgressProps> = (props) => {
  return <CircularProgress css={classes.root} {...props} />;
};
export default Spinner;
