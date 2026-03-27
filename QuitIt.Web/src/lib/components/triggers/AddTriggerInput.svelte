<script>
	let { value = $bindable(""), disabled = false } = $props();
</script>

<input class="input" type="text" bind:value {disabled} placeholder="What triggers you?" />

<style>
	input[type="text"] {
		padding: 1rem;
		border-bottom: 2px solid black;
		border-radius: 1rem 1rem 8px transparent 0;
		border-top: none;
		border-left: none;
		border-right: none;
		background: #f9fafb;
		font-size: 1rem;
		outline: none;
		appearance: none;
	}
</style>
