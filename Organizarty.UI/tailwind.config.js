/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./Blazor/**/*.{razor,cshtml.html}",
    "./node_modules/flowbite/**/*.{js,razor,html,cshtml}"
  ],
  theme: {
    extend: {},
  },
  plugins: [
    require('flowbite/plugin')
  ],
}

