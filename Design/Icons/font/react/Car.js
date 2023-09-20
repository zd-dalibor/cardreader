import React from 'react';
export const Car = props => (
  <svg viewBox="0 0 20 20"  {...props} className={`CardReader ${props.className ? props.className : ''}`}><path d="M2 12H.5a.5.5 0 0 1 0-1h1.71l3.568-6.247A1.487 1.487 0 0 1 7.075 4h14.848a1.489 1.489 0 0 1 1.299.752L26.79 11h1.71a.5.5 0 0 1 0 1H27v10.5c0 .823-.677 1.5-1.5 1.5h-3c-.823 0-1.5-.677-1.5-1.5V20H8v2.5c0 .823-.677 1.5-1.5 1.5h-3c-.823 0-1.5-.677-1.5-1.5V12Zm23.639-1-3.286-5.753A.488.488 0 0 0 21.927 5H7.073a.488.488 0 0 0-.426.247L3.361 11h22.278ZM26 20h-4v2.5c0 .274.226.5.5.5h3c.274 0 .5-.226.5-.5V20Zm-4.5-1H26v-7H3v7h18.5ZM3 20v2.5c0 .274.226.5.5.5h3c.274 0 .5-.226.5-.5V20H3Zm3.5-4a.5.5 0 0 1 0-1h2a.5.5 0 0 1 0 1h-2Zm14 0a.5.5 0 0 1 0-1h2a.5.5 0 0 1 0 1h-2Zm-9-15a.5.5 0 0 1 0-1h6a.5.5 0 0 1 0 1h-6Z" fillRule="evenodd" /></svg>
);
