<script>
	let { value = $bindable(""), disabled = false } = $props();
</script>

<input class="input" type="text" bind:value {disabled} />

<style>
	.input {
		padding: 12px 14px;
		border: 2px solid transparent;
		border-radius: 8px;
		background: #f9fafb;
		font-size: 16px;
		transition: all 0.2s ease;
	}

	.input:focus {
		background: white;
		border-color: #6366f1;
		box-shadow: 0 0 0 3px rgba(99, 102, 241, 0.2);
	}
</style>
