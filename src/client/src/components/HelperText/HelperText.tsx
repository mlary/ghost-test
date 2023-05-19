/** @jsxImportSource @emotion/react */
import { css } from '@emotion/react';

const classes = {
  root: css({
    color: 'var(--error-color)',
    fontSize: '0.8rem',
    lineHeight: '10px',
    margin: 0,
    marginTop: 8,
    marginLeft: 4,
  }),
};
const HelperText = ({ error, helperText }: { error: boolean; helperText?: string }) => {
  return <>{error && helperText && <p css={classes.root}>{helperText}</p>}</>;
};
export default HelperText;
