import React from 'react';
import userManager from '@/utils/userManager';

export default (props: any) => {
  userManager
    .signinSilentCallback()
    .then(response => {
      console.log(response);
    })
    .catch(err => {
      console.log(err);
    });

  return <div>redirect...</div>;
};
