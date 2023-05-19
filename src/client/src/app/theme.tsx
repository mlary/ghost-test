import { Interpolation } from '@emotion/react';
import { createTheme } from '@mui/material';



export const DEFAULT_THEME = createTheme({
  typography: {
    fontFamily: "var(--main-font)"
  },
  palette: {
    text: {
      primary: '#1f2c3d',
    },
    primary: {
      main: '#1f2c3d',
    },
  },
});
export type MThemeStyle = Interpolation<typeof DEFAULT_THEME>;

export type MTheme = {
  [keyL: string]: MThemeStyle;
};

export default MTheme;
